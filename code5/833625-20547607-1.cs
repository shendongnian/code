    string conString = ".....";
    using(SqlConnection con = new SqlConnection(conString))
    using(SqlCommand cmd = new SqlCommand("Select ID, Name from Student", con))
    {
       con.Open();
       using( SqlDataReader dr = cmd.ExecuteReader())
       while (dr.Read())
       {
            Console.WriteLine("Id is:"+dr[0]+" Name is:"+ dr[1]);
       }
    }
