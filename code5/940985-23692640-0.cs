    var predicate = PredicateBuilder.False<ParentTable>();
    predicate = predicate.Or(p => p.ChildTable.Any(c => c.Name.StartsWith("#"));
    
    var keywords = "search terms go here";
    foreach (var keyword in keywords)
    {
      var temp = keyword;
      predicate = predicate.Or(p => p.ChildTable.Any(c => c.Name.Contains(temp));
    }
    
    using(var dc = TestDataContext())
    {
      Console.WriteLine(dc.ParentTable.Where(predicate).Count());
    }
