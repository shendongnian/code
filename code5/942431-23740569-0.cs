    db.Cats
      .GroupBy(x => x.Category)
      .Select(x => new
       {
           Category = x.Key,
           SubCategories = x.Select(s => s.SubCategory).Distinct()
       });
