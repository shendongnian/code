      var predicate = PredicateBuilder.False<Product>();
    
      foreach (string keyword in keywords)
      {
        string temp = keyword;
        predicate = predicate.Or (p => p.Description.Contains (temp));
      }
      return dataContext.Products.Where(predicate).ToList();
