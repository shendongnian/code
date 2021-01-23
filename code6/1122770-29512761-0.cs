    var result = from item in db.Items
              group item by new { item.BrandId, item.ModelId, item.TotalPrice }
              into gr
              select new 
              {
                  gr.Key.BrandId,
                  gr.Key.ModelId,
                  gr.Key.TotalPrice,
                  CountA = gr.Count(it => it.StoreId == 1),
                  CountB = gr.Count(it => it.StoreId == 2),
              }
