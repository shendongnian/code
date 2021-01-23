            // your retun objects
            var products = new List<ProductDataContract>();
            using (
                var db =
                    new DataClassesDataContext(
                        ConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString))
            {
                foreach (var prod in db.Products.Select(p => new Products {ProductId = p.ProductId}))
                {
                    prod.Categorieses = new List<IProductCategories>();
                    foreach (var category in db.ProductCategories.Where(c => c.ProductId == prod.ProductId))
                    {
                        prod.Categorieses.Add(new ProductCategories(category.ProductId, category.ProductCategoryName));
                    }
                    products.Add(new ProductDataContract {Categorieses = prod.Categorieses, ProductId = prod.ProductId});
                }
            }
