    using(SqlDataReader dReader = cmd.ExecuteReader())
    {
         // First item displayed on the textbox
         if(dReader.HasRows)
              txtSearch.Text = dReader["Name"].ToString();
    
         // Continue looping on every record and copy the name field in a list
         List<string> names = new List<string>()
         while (dReader.Read())
         {
              names.Add(dReader["Name"].ToString());
         }
    
         // Here you have you list of names in memory to be used where you need it
    }
