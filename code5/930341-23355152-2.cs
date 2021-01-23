    protected void Button4_Click(object sender, EventArgs e)
    {
    	string conString ="xxxxxxxxxxxxxxxxxxxxxxxxxx";
    	using (SqlConnection con = new SqlConnection(conString))
    	{
    	    con.Open();
    	    using (var cmd = new SqlCommand("select * from Users where UserId=@UserId",con))
    	    {
    			var id= Convert.ToInt32(Session["ID"]);
    			cmd.Parameters.AddWithValue("@UserId",id);
    			using (SqlDataReader reader = cmd.ExecuteReader())
    			{
    				//get the data
    			}		
    	    }
    	}
    }
