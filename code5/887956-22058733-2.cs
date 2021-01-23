    string query = "SELECT * FROM page_counter where month = @month  AND year = @year;";
    //Open connection
    if (this.OpenConnection() == true)
    {
      //Create Command
      MySqlCommand cmd = new MySqlCommand(query, connection);
      cmd.Parameters.AddWithValue("@month",month);
      cmd.Parameters.AddWithValue("@year",year );
           //Remaining same
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();
            //Read the data and store them in the list
            while (dataReader.Read())
            {
                list[0].Add(dataReader["id"].ToString() + "");
                list[1].Add(dataReader["month"].ToString() + "");
                list[2].Add(dataReader["year"].ToString() + "");
                list[3].Add(dataReader["page_count"].ToString() + "");
            }
            //close Data Reader
            dataReader.Close();
          
