    using (var db = GetMyEntities())
    {
        List<IEnumerable<object>> recordsList = AllEntities(db);
        foreach (IEnumerable<object> records in recordsList)
        {
            foreach (object record in records)
            {
                // Do something with record.
                //  If you need to access type-specific properties,
                //   do something like below
                if (record is UserAccount)
                {
                    UserAccount account = (UserAccount)record;
                    Console.WriteLine("User Name: " + account.UserName);
                }
            }
        }
    }
