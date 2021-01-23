    public string GetSortCriteria(this SortingItem item){
       return string.Format("{0} {1}", item.PropertySelectorString, 
        	  item.SortingDirections == SortingDirectionsEnum.Descending ? 
                 "DESC" : "ASC");
    }
    // later: 
    var mergedSortCriteria= string.Join(",", 
         SortingItems.Select(item => item.GetSortCriteria());
    
    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> myFunc = 
          source => source.OrderBy("id " + mergedSortCriteria);
