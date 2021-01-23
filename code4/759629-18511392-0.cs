    SqlConnection con=new SqlConnection("YourConnection String");
    SqlCommand cmd=new SqlCommand();
    SqlDataAdapter da=new SqlDataAdapter();
    DataSet ds = new DataSet();
    cmd = new SqlCommand("name of your Stored Procedure", con);
    cmd.CommandType = CommandType.StoredProcedure;
    //cmd.Parameters.AddWithValue("@SuperID", id);//if you have parameters.
    da = new SqlDataAdapter(cmd);
    da.Fill(ds);
    con.Close();
