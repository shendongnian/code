     DataTable dtTable = new DataTable();
     using (SqlDataReader sqlDataReader = objcmd .ExecuteReader())
     {
        dtTable.Load(sqlDataReader);
        qlDataReader.Close();
    }
    dview.DataSource = dtTable;
    dview.DataBind()
