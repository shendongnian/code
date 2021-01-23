    using (IDataReader rdr = Database.ExecuteReader(reportbase.command))
    {
        while (rdr.Read())
        {                    
            var value = new RDLCReportBase
                {
                    Property1 = rdr.GetInt32(0), // access zero column value wich is type of int
                    Property2 = (string)rdr["Column2"], // access column value with name Column2 wich is type of string
                    // and so on...
                };
            list.Add(value);
        }
    }
