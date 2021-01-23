    public DataSet GetPerson(IEnumerable<string> wantedColumns)
    {
        using(SqlConnection connection = new SqlConnection("Connection-String"))
        using (SqlDataAdapter _daPerson = new SqlDataAdapter("SP-GetAllPerson", connection))
        {
            _daPerson.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            DataSet _personDs = new DataSet();
            _daPerson.Fill(_personDs, "TBL_Person");
            DataTable tblPersonIds = _personDs.Tables["TBL_Person"];
            var allColumns = tblPersonIds.Columns.Cast<DataColumn>().Select(c => c.ColumnName);
            // remove unwanted columns:
            foreach (string columnToRemove in allColumns.Except(wantedColumns))
                tblPersonIds.Columns.Remove(columnToRemove);
            return _personDs;
        }
    }
