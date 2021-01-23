     public DataTable bindGridView() 
    	{
    	 string txtSearch = txtSearchRP.Text;
         DataTable dt = new DataTable();
         using (SqlConnection con = new SqlConnection(cn.ConnectionString))
            {
                SqlCommand cmdd = new SqlCommand();
                cmdd.CommandType = CommandType.StoredProcedure;
                cmdd.CommandText = "sp_Search";
                 cmdd.Parameters.AddWithValue("@txtSearch", txtSearch);
                cmdd.Connection = con;
                con.Open();
                SqlDataAdapter dap = new SqlDataAdapter(cmdd);
                DataSet ds = new DataSet();
                dap.Fill(ds);
                dt = ds.Tables[0];
                con.Close();
    
            }
    		return dt;
    	}
