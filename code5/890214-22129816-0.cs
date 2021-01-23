    String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["randolphConnectionString"].ConnectionString;
    using(SqlConnection con = new SqlConnection(strConnString))
    using(SqlCommand cmd = con.CreateCommand())
    {
         string strQuery = @"UPDATE pages SET en_content = @en_Content, fr_Content = @fr_content, fr_Title=@fr_title, en_Title=@en_title, [update]=@update WHERE link_title = @link_title";
         cmd.CommandText = strQuery;
         cmd.Parameters...;
         .....
         .....
         cmd.Connection.Open();
         cmd.ExecuteNonQuery();
    }
