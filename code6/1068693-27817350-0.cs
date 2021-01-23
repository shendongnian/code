    SqlConnection con=new SqlConnection("ConnecttionString"); 
    con.Open();
    SqlCommand cmd = new SqlCommand("ProcedureName", con);
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Parameters.AddWithValue("StoredProcedureParameter", Value);
    SqlDataAdapter adp = new SqlDataAdapter(cmd);
    DataTable dt = new DataTable();
    adp .Fill(dt);
    con.Close();
    if (dt.Rows.Count > 0)
    {
     // get the data table field value here 
    }
    else
    {
    // Table is Empty 
    }
