    using(var db = new DbContext()) //Replace for your context
    {
        while (!jobDone)
        {
            foreach(var one in retrunData)
            {
                try
                {
                    targetTable row = new TargetTable();
                    dbconn.TargetTable.add(row);
                    dbconn.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("DB Insertion Fail.");
                }
            }
        }
    }
This way, even if your code fails at some point, the Context, resources and connections will be properly disposed.
