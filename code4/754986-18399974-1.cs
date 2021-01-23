    public static LinqResults Create()
    {
        DataDataContext dc = new DataDataContext();
        LinqResults linqResults = new LinqResults(
            from job in dc.Jobs
            where job.Status == "Active"
            select new LinqResult
            {
                JobNum = job.Job1,
                CustomerName = job.Customer,
                Order_Date = job.Order_Date,
            });
        return linqResults;
    }
