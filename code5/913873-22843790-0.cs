    public IEnumerable<T> ExecuteSort<T>(
       IQueryable<T> src, Expression<Func<T,bool>> predicate, SortOrder sortOrder)
    {
         if (sortOrder == SortOrder.Ascending)
         {
             return src.OrderBy(predicate));
         }
         else
         {
             return src..OrderByDescending(predicate));
         }
    }
    
    ExecuteSort(src, v => v.Price, ortOrder.Ascending); 
