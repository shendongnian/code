    [HttpGet]
        [Queryable()]
        public IQueryable<TopBusinessCategory> GetTopBusinessCategories()
        {
            var top = (from p in Db.BusinessCategories
                      join c in Db.Reviews on p.BusinessID equals c.BusinessID into j1
                      from j2 in j1.DefaultIfEmpty()
                      group j2 by p.Category into grouped
                      select new TopBusinessCategory
                      {
                          BusinessCategory = grouped.Key,
                          Count = grouped.Count(t => t.BusinessID != null)
                      }).OrderByDescending(x => x.Count).Take(25);
            return top.AsQueryable();
        }
