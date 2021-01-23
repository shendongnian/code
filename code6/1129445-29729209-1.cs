    public DataSet returnCustomer(collection b)
       {
           try
           {
               DataSet _ds = new DataSet();
               _ds.Tables.Add(DAL.GetCustomer(b));
               return _ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
