    string cmdText = "Select login_time_value,logout_time_value ConnectionTime.dbo.Avalaible " + 
                     "FROM ??????????" + 
                     "where name = @name";
    using(SqlConnection sqlConnection = new SqlConnection(ConnectDatabase))
    using(SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection))
    {
        sqlCommand.Parameters.AddWithValue("@name", "dummy");
        sqlConnection.Open();
        for(x = 0; x < listBoxControl2.Items.Count; x++)
        {
             string name = listBoxControl2.Items[x].ToString();
             sqlCommand.Parameters["@name"].Value = name;
             using(SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
             {
                  ......
             }
        }
    }
