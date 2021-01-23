        public DataTable BindRole()
            {
        
        try
        {
                    Database _database = DatabaseFactory.CreateDatabase();
                    DbCommand dbCommand = _database.GetSqlStringCommand(QMROLE.FetchData);
                    DataSet _ds = _database.ExecuteDataSet(dbCommand);
                    return _ds.Tables[0];
        }
        catch
        {
        throw; //rethrows the exception
    // retrun null;  retun null
    // return new DataSet(); return a new empty object
        }
    
            }
