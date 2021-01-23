    string strcon = ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;
    con.ConnectionString = strcon;
    con.Open();
    SqlCommand cmd = new SqlCommand("[Your_StoredProcedureName]", con);
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    
    da.SelectCommand.CommandType = CommandType.StoredProcedure;
    da.SelectCommand.Parameters.AddWithValue("@value1", value1);
    da.SelectCommand.Parameters.AddWithValue("@value2", value2);
    da.SelectCommand.Parameters.AddWithValue("@value3", value3);
    int result = da.SelectCommand.ExecuteNonQuery();
    return result ;
