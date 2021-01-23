    private void BindGrid()
    {
    	var CurrentUser = User.Identity.Name;
    	string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    	using (SqlConnection con = new SqlConnection(constr))
    	{
    
    		if (CurrentUser != null)
    		{
    		using (SqlCommand cmd = new SqlCommand())
    			{
    				GridView GridView1 = LoginView3.FindControl("GridView1") as GridView;
    				cmd.CommandText = "select Id, Name from tblFiles WHERE email = @CurrentUser";
    				cmd.Parameters.Add("@CurrentUser", SqlDbType.NVarChar);
    				cmd.Parameters["@CurrentUser"].Value = User.Identity.Name;
    				cmd.Connection = con;
    				con.Open();
    				GridView1.DataSource = cmd.ExecuteReader();
    				GridView1.DataBind();
    				con.Close();
    				
    			}
    		}
    	}
    }
