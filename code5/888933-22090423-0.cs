    var query = dbContext.Protypes.Join(dbContext.Products,
                      protype => protype.idType,
                      product => product.idType,
                      (protype, product) => new { Protype = protype, Product = product })
                      .GroupBy(s => new { s.Protype.idType, Product.TypeName })
                      .Select(s => new
                      {
                         IdType = s.First().Protype.idType,
                         TypeName = s.First().Product.TypeName,
                         Count = s.Count()
                      });
