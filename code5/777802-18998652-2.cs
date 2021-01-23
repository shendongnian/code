    public DataTable BindRole()
    {
        DataTable dataTable = new DataTable();
        try
        {
            Database _database = DatabaseFactory.CreateDatabase();
            using (DbCommand dbCommand = _database.GetSqlStringCommand(QMROLE.FetchData))
            {
                using (DataSet _ds = _database.ExecuteDataSet(dbCommand))
                {
                    dataTable = _ds.Tables[0];
                }
            }
        }
        catch
        {
        }
        finally
        {
            // perform cleanup
        }
        return dataTable;
    }
