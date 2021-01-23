    var keywords=new List<string>(){ "Test1","Test2" };
    var predicate = PredicateBuilder.False<QuestionsMetaDatas>();
    
    foreach (var key in keywords)
    {
      predicate = predicate.Or (a => a.Text.Contains (key));
    }
    var query = context.QuestionsMetaDatas.AsQueryable().Where(predicate);
