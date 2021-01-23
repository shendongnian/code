    using (var dc = new TestDataContext()) //my test DataContext
    {
        dc.Log = Console.Out; //it's of TextWriter type, use any suitable
        IQueryable<Employee> query = ...; //your query
       
        //execute the query, as it'll output the query to the Log only after it's
        //really executed on the database
        foreach (var s in query)
        {
            //...
        }
    }
