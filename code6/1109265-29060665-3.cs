    DataSet loDataSet = new DataSet();
    msQuery = "SELECT * FROM [TableName]";
    Execommand(msQuery);
    moAdapter.Fill(loDataSet);
    DataTable loTable = new DataTable();
    loTable = loDataSet.Tables[0];
    if (loTable != null && loTable.Rows.Count > 0)
    {
        foreach (DataRow foRow in loTable.Rows)
        {
           string lsUserID = Convert.ToString(foRow["UserID"]);
        }
    }
