    protected void myGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    	var id= int.Parse(e.CommandArgument);
    	_connString = ConfigurationManager.AppSettings["connString"];
    	using (SqlConnection conn = new SqlConnection(_connString))
    	{
    		conn.Open(); 
    		using(SqlCommand cmd = new SqlCommand("update ref_registration_company_user set ind_active=1 where id_company_user=id_company_user", conn))
    		{
    		   cmd.Parameters.AddWithValue("@id_company_user", id);
    		   cmd.ExecuteNonQuery();
    		}
    	}  
    }
