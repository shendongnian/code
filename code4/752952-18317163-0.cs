    SqlConnection conn = new SqlConnection(connString);
    SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_tblname", conn);
    try
    {
         
         conn.Open();
         DataSet ds = new DataSet();
         SqlDataAdapter da = new SqlDataAdapter();
         da.SelectCommand = cmd; // Set the select command for the DataAdapter
         da.Fill(ds); // Fill the DataSet with the DataAdapter
         DataGridView1.DataSource = ds.Tables[0]; // I just displayed the results in a grid view for simplicity.  If Asp.Net you will have to call a DataBind of course.
    
    catch (Exception ex)
    {
         conn.Close();
         conn.Dispose();
    }
