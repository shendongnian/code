    public static IQueryable<T> CategoryFilter<T>(IQueryable<T> queryable1, int categoryFilterCount, object rc, bool CategoryOR, string categoriesforQuery) where T : AbstractResult
        {
            if (!string.IsNullOrEmpty(categoriesforQuery))
            {
                string[] categoriesDefined = categoriesforQuery.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                ConcurrentBag<T> listInitialResult = new ConcurrentBag<T>();
                Parallel.ForEach(categoriesDefined, (TaxonomyID) =>
                {
                    string categoryToCompare = TaxonomyID.ToString().Replace("{", "").Replace("}", "");
                    var queryable = queryable.Where(i => i.alltags.Contains(categoryToCompare));
                    List<T> queryableListdResult = queryable.ToList();
                    for (int i = 0; i < queryableListdResult.Count; i++)
                    {
                        listInitialResult.Add(queryableListdResult[i]);
                    }
                });
                if (CategoryOR)
                {
                    return listInitialResult.AsQueryable();
                }
                else
                {
                    List<T> queryableFinalResult = (listInitialResult.GroupBy(x => x._Group).Where(g => g.Count() >= categoryFilterCount)
                    .Select(g => g.FirstOrDefault())).ToList();
                    return queryableFinalResult.AsQueryable();
                }
            }
            else
            {
                return queryable;
            }
        }
