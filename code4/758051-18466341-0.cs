    public int UpdateDataObject(ClrDataObject clrDataObject)
    {
        using (MySqlDataContext dataContext = new MySqlDataContext())
        {
            MySqlDataObject mySqlDataObject = dataContext.MySqlDataObjects.Where(d => 
    d.Id == clrDataObject.Id).FirstOrDefault();
            CopyToMySqlDataObject(clrDataObject, mySqlDataObject);
            dataContext.SubmitChanges(ConflictMode.FailOnFirstConflict);
            return 0;
        }
        ...
        using (OracleDataContext dataContext = new OracleDataContext())
        {
            OracleDataObject oracleDataObject = dataContext.OracleDataObjects.Where(d => 
    d.Id == clrDataObject.Id).FirstOrDefault();
            CopyToOracleDataObject(clrDataObject, oracleDataObject);
            dataContext.SubmitChanges(ConflictMode.FailOnFirstConflict);
            return 0;
        }
    }
