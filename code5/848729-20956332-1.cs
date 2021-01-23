           try
           {
                var db = new MyWebServiceDatabaseDataContext();
                var myTable = from a in db.MyTable
                              select a;
                return myTable.ToList();
            }
            finally
            {
                db.Dispose();
            }
  
