    if (Request.QueryString["id"] != null)
    {
        string conString = "xxxxxxxxxxxxxxxxxxxxxxxx";
        using (SqlConnection con = new SqlConnection(conString))
        {
            con.Open();
            using (var cmd = new SqlCommand(
            "select * from messages where messageid =@catid",
            con))
            {
                cmd.Parameters.AddWithValue("@catid", catid);
    
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                  //get the data
                } 
            }
        }
    }
