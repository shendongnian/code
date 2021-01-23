          public List<Product> StoveProducts
          {
              get
              {
                  return AllProducts.Where(p => p.Category == "Stoves").ToList();
              }
          }
