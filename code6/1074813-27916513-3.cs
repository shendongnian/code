        var duplicates = (from o in db.Products
                  select new
                  {
                      codeCount = db.Products.Where(c => c.Code == entity.Code).Count(),
                      nameCount = db.Products.Where(c => c.Name == entity.Name).Count(),
                      otherFieldCount = db.Products.Where(c => c.OtherField == entity.OtherField).Count()
                  }).FirstOrDefault();
