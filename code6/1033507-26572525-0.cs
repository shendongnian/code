    SqlConnection conn = new SqlConnection("YourConnectionString");
    
    conn.Open();
    
    SqlCommand cmd = new SqlCommand("Query for fetching your data", conn);
    //cmd.Parameters.AddWithValue("@P1", p1Value); if the query need parameters to prevent sql injection.
    
    DataSet resultDst = new DataSet();
    
    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
    {
        dapter.Fill(resultDst, "TableName");
    }
    
    conn.Close();
    
    foreach(DataRow row in resultDst.Tables[0].Rows)
    {
       //manuipulate the data if needed
       //row["ColumnName"] = some value;
    }
    
    
    //if this is winforms you need only datagrid dataSource property to be set, if you are using asp.net //you need to databind after that.
    
    dataGridView1.DataSource = resultDst.Tables[0];
