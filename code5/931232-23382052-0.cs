    private static readonly HashSet<string> allowedColumns = new HashSet<string>{ 
        "Person_ID", "FirstName", "LastName", "Age", "Location" 
    };
    public DataSet GetPerson(IEnumerable<string> columns)
    {
        if(columns == null || !columns.Any())
            columns = allowedColumns;
        if(columns.Except(allowedColumns).Any())
            throw new ArgumentException(string.Format("Only these columns are allowed: {0} so {1} is not allowed.",string.Join(",",allowedColumns),string.Join(",",columns.Except(allowedColumns))), "allowedColumns");
        
        using(SqlConnection connection = new SqlConnection("Connection-String"))
        using (SqlDataAdapter _daPerson = new SqlDataAdapter("SP-GetAllPerson", connection))
        {
            _daPerson.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            DataSet _personDs = new DataSet();
            _daPerson.Fill(_personDs, "TBL_Person");
            DataTable tblPersonIds = _personDs.Tables["TBL_Person"];
            // remove unwanted columns from the DataTable:
            foreach (string columnToRemove in allowedColumns.Except(columns))
                tblPersonIds.Columns.Remove(columnToRemove);
            return _personDs;
        }
    }
