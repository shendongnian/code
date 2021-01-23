    Task task = new Task(() =>
    Parallel.ForEach(l.departments, new ParallelOptions { MaxDegreeOfParallelism = -1 }, (department) =>
    {
        // Now local to the executing thread.
        DBRepository db = new DBRepository(l.connectionString);
        
        DateTime ChangesFromTS = GetPreviousIterationTS;
        List<DataObj> cdata = db.GetChangedDataDB(ChangesFromTS);
        // ... doing the work here
    }
    )); //close lambda expression
        
    task.Start();
