    collection.QueryablePlusPlus()
              .Select(c => new {
                  OriginalDoc = c,
                  SortKey = c.mobileView + c.webView
              })
              .OrderByDescending(c => c.SortKey)
              .Take(10)
              .Select(c => c.OriginalDoc)
