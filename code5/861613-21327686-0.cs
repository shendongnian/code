    db.Products.Join(db.CustomerPrices, 
                     p => p.ProductId,  
                     c => c.ProductId, 
                    (p,c) => new { Product = p, cust = c })
                .Where(p => p.Product.LockedSince.Equals(null))
                .Select(p => new {
                           ProductId = p.Product.ProducId,
                           Name = TranslationHelper.GetProductTranslation(p.Product.ProductId, ProductTranslationField.Name, p.Product.Name),
                           ...
                           });
