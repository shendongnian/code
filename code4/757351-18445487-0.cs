    var projects = Adapter.CategoryRepository
                          .Get()
                          .Where(c => c.CategoryID == catID)
                          .Select(c => c.Projects)
                          .Distinct();
