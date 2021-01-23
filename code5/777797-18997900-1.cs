    public DataTable BindRole()
    {  
       DataSet _ds = new DataSet();
       try
       {
        Database _database = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = _database.GetSqlStringCommand(QMROLE.FetchData);
        DataSet _ds = _database.ExecuteDataSet(dbCommand);    
        return _ds.Tables[0];
       }
       catch(Exeption Ex)
       {
        // either trow the exception or 
        // return an empty datatable here
        return new DataTable();
       }       
    }
