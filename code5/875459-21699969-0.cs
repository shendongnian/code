    {
        string strTableName=string.empty;
        SqlConnection source = new SqlConnection(strConnectDB1);
        SqlConnection destination = new SqlConnection(strConnectDB2);
        source.Open();
        destination.Open();
        SqlCommand cmd= new SqlCommand("SELECT * FROM"+strTableName, source);
        strTableName=listbox1.SelectedItem.ToString());
        SqlDataReader reader = cmd.ExecuteReader();
        SqlBulkCopy bulkData = new SqlBulkCopy(destination);
        bulkData.DestinationTableName = listbox1.SelectedItem.ToString();
        bulkData.WriteToServer(reader);
        .
        .
    }
