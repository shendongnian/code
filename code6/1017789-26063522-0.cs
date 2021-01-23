    using(SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Waves;Integrated Security=true;"))
    {
    	con.Open();
    	
    	using(SqlCommand com = new SqlCommand("Update_Project", con))
    	{
    		com.CommandType = CommandType.StoredProcedure;
    		com.Parameters.AddWithValue("@ProjectID",Label1.Text);
    		com.Parameters.AddWithValue("@ProjectName",txtName.Text);
    		com.Parameters.AddWithValue("@VideoUrl", txtName.Text);
    		com.Parameters.AddWithValue("@Notes", txtName.Text);
    		com.Parameters.AddWithValue("@Date",DateTime.Now.Date);
    		WavesEntities wee = new WavesEntities();
    		var query = from p in wee.Project_Images
    					select p.img_Id;
    	}
    	
    	using(SqlCommand com1 = new SqlCommand("UpdateProjectImages", con))
    	{
    		com.CommandType = CommandType.StoredProcedure;
    
    
    		com.Parameters.AddWithValue("@img_id", query.AsEnumerable());
    		com.Parameters.AddWithValue("@img_path", con);
    		con.Open();
    		com.ExecuteNonQuery();
    	}
    }
