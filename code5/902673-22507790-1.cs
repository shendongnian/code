     var result = from r in query.AsEnumerable()
                  group r by new { r.CustomerName, r.CustomerEmail } into g
                  select new CustomerSearchResult {
                     CustomerName = g.Key.CustomerName,
                     CustomerEmail = g.Key.CustomerEmail,
                     ItemNames = String.Join(",", g.Select(r => r.ItemName))
                  };
