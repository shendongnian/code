    SqlCommand comnd = new SqlCommand(query, con);
    con.Open();
    SqlDataAdapter da = new SQlDataAdapter(comnd); // create a DataAdapter
    DataSet ds = new DataSet();
    StreamWriter strmwr = new StreamWriter(Location);   // Not sure what this is for
    da.Fill(ds);  // fill the DAtaSet
    
    foreach (DataRow in ds.Tables[0].Rows
