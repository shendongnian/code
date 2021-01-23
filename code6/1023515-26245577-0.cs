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
