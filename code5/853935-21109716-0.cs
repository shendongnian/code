    context = new Context();
    var transaction = context.Database.BeginTransaction();
    List<object> results = context.someQuery.ToList();
    // do stuff to results to get it ready for processing in the for loop
    
    for (int i = 0; i < results.Count; i++)
    {
        // do stuff like Add and Modify
        if (results[i] == target)
            context.myDataSet.DeleteObject(target);
        if (i % 10 == 0)
            context.SaveChanges();
        if (i % 100 == 0)
        {
            transaction.Commit();
            transaction.BeginTransaction();
        }
    }
