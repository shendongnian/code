    public DataTable BindRole()
    {  
       try
       {
        Database _database = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = _database.GetSqlStringCommand(QMROLE.FetchData);
        DataSet _ds = _database.ExecuteDataSet(dbCommand);    
       }
       catch(Exeption Ex)
       {
        // either trow the exception or 
        // return an empty datatable here
        return new DataTable();
       }
       return _ds.Tables[0];
    }
