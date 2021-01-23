    var results = (from c in e.Customers
                   where m.Name.Contains(name)
                   select new { c.CustomerId, c.NAME, c.CITY, c.STATE, c.COUNTRY })
                  .Distinct()
                  .OrderBy(s => s.NAME)
                  .ThenBy(s => s.CITY)
                  .ThenBy(s => s.CustomerId)
                  .ToList();
    totalCount = results.Count;
    return results.Skip(skipCount).Take(pageSize).ToList();
