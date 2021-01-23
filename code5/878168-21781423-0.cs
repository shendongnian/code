      var predicate = PredicateBuilder.False<Product>();
    
      foreach (string keyword in keywords)
      {
        string temp = keyword;
        predicate = predicate.Or (p => p.Description.Contains (temp));
      }
    
      var products = productRepository.Get(predicate)
