    using (SqlConnection con = new SqlConnection(strCon)) 
    {
        using (SqlCommand cmd = new SqlCommand(strCmdText, con)) 
        {
            con.Open();
            using (SqlDataReader dr = cmd.ExecuteReader())
             {
                  //do stuff;
                  dr.Close();
             }
         }
         con.Close();
    }
