﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SleekEcommerce.Data;
using SleekEcommerce.Models;

namespace SleekEcommerce.Pages.products
{
    public class IndexModel : PageModel
    {
        private readonly SleekEcommerce.Data.SleekEcommerceContext _context;

        public IndexModel(SleekEcommerce.Data.SleekEcommerceContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get => _context.Products.ToList(); set { Products = value; } }

        public async Task OnGetAsync()
        {
            if (_context.Products != null)
            {

                //Products = await _context.Products.ToListAsync();
                
            }
        }


        public void OnPostAddToCart(int productId)
        {
            Helpers.CartHelper cartHelper = new Helpers.CartHelper();

            Product product = _context.Products.FirstOrDefault(x => x.Id == productId);
            cartHelper.AddToCart(product, this.Request, this.HttpContext);

        }

    }
}
