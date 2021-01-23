         List<Dictionary<string, string>> rows = new List<Dictionary<string, string>>();
         Dictionary<string, string> column; 
         string sqlQuery = "SELECT USER_ID, FIRSTNAME, LASTNAME FROM USERS";
        SqlCommand command = new SqlCommand(sqlQuery, myConnection);
        try
        {
            myConnection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {    //Every new row will create a new dictionary that holds the columns
                 column = new Dictionary<string, string>(); 
                 column["USER_ID"] = reader["USER_ID"].ToString();
                 column["FIRSTNAME"] = reader["FIRSTNAME"].ToString();
                 column["LASTNAME"] = reader["LASTNAME"].ToString();
                 rows.Add(column); //Place the dictionary into the list
            }
            reader.Close();
        }
        catch (Exception ex)
        { 
             //If an exception occurs, write it to the console
             Console.WriteLine(ex.ToString());
        }
        finally
        {
            myConnection.Close();
        }
        //Once you've read the rows into the collection you can loop through to                     
        //display the results
        foreach(Dictionary<string, string> column in rows)
        {
            Console.Write(column["USER_ID"]) + " ";
            Console.Write(column["FIRSTNAME"] + " ";
            Console.Write(column["LASTNAME"] + " ";
            Console.WriteLine();
        }
