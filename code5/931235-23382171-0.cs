    public DataSet GetPerson()
    {
        SqlCommand _select = new SqlCommand();
        _select.CommandText = "SP-GetAllPerson";
        _select.CommandType = System.Data.CommandType.StoredProcedure;
        _select.Connection = Connection.GetConnection; 
        SqlDataAdapter _daPerson = new SqlDataAdapter(_select);
        DataSet _personDs = new DataSet();
        _daPerson.Fill(_personDs, "[TBL_Person]");
        _personDs.Tables["TBL_Person"].Columns.Remove("Person_ID");
        _personDs.Tables["TBL_Person"].Columns.Remove("Location");
        return _personDs;
    }
