    parents.OrderByWithTieBreaker(x=>x.Age)
    
    OrderByWithTieBreaker(this parents, lambda){
      var returnedList = new List<T>()
      var orderedParents = parents.OrderBy(lambda)
      var groupings = orderedParents.GroupBy(lambda)
      foreach(var grouping in groupings){
        if(grouping.Count() > 1)
        {
           var innerOrder = grouping.OrderByWithTieBreaker(lambda)
           list = list.Union(innnerOrder)
        }
        else
            list.Insert(grouping)
      }
      return list
    }
