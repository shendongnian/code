    var dictionary = items.SelectMany(i => i.RelatedCategories
                                            .Concat(Enumerable.Repeat(i.mainCat, 1))
                                            .Select(c => new { c.CatName, Item = i}))
                          .GroupBy(a => a.CatName)
                          .ToDictionary(a => a.Key, a => a.ToList());
