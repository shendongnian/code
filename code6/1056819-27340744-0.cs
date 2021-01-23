    DataSet ds = null;
    try
    {
        string str = ConfigurationManager.ConnectionStrings["e_con_connection"].ConnectionString;
        SqlConnection con = new SqlConnection(str);
        SqlCommand cmd = new SqlCommand("GetProduct",con);
    
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ProductId", productid);
    
        SqlDataAdapter da = new SqlDataAdapter();
        ds = new DataSet();
        da.Fill(ds);
    }
    catch (Exception e)
    {
        //throw new Exception( message.ex);
        HttpContext.Current.Response.Redirect("~/Error.aspx?err=" + e.Message);
    }
    
    
    return ds;
