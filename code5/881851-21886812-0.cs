    List<string> strNames=new List<string>();
    using(SqlConnection con = new SqlConnection("connection string here"))
    using(SqlCommand command = new SqlCommand("select Name from mytable",con))
    {    
       con.Open();
       SqlDataReader reader = command.ExecuteReader();
       while (reader.Read())
       {
         strNames.Add(reader["Name"]);
       }
    }
