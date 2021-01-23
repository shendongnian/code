    orders.Where(o => o.Supplier != null &&
                      o.ProductTitle != null &&
                      o.Code != null &&
                      o.MaxPrice != null)
          .GroupBy(g => new { o.ProductTitle, o.Code })
          .Select(g => new
              {
                  ProductTitle = g.Key.ProductTitle,
                  Code = g.Key.Code,
                  MaxPrice = g.Max(x => o.MaxPrice)
              });
