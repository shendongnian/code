    var res = (from p in swd.Products
              join c in swd.Categories on p.CategoryID equals c.CategoryID
              join s in swd.Suppliers on c.CategoryID equals s.SupplierID
              orderby p.ProductID
              select new AS3.Models.MyModel
              {
                  ProductID = p.ProductID,
                  ProductName = p.ProductName,
                  CategoryName = c.CategoryName,
                  CompanyName = s.CompanyName,
                  ContactName = s.ContactName,
                  Country = s.Country
              }).ToList();
