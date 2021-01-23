    public void foo()
    {
      // List of predicates for order detail
      var predicates = new List<DetailPredicate>();
      // Logic to determine what predicates get added to list
      if(somelogic)
        predicates.Add(d => d.Product.UnitPrice >= 5);
      if(somethingelse)    
        predicates.Add(d => d.Product.UnitPrice <= 2);
  
      // Default to true
      var whereDetails = PredicateBuilder.True<Order_Details>();
      if (predicates.Any())
      {
         // Aggregate predicates with OR in between
         whereDetails = predicates.Aggregate(PredicateBuilder.Or);
      }
      // Apply aggregate
      CustomerPredicate PriceMoreThan5orLessThan2 = c => 
          c.Orders.Any(o => 
              o.Order_Details.Any(whereDetails);
