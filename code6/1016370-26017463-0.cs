    List<int> xValues = new List<int>();    
    SqlDataReader dr = cmd.ExecuteReader();
    if(dr.HasRows) //Check if datareader is not null, allways do this.
        while (dr.Read())
        {
            int number;
            bool result = Int32.TryParse(dr["items"], out number);
            if (result) //check if its really a number
            {
                xValues.Add(number);         
            }
            else
            {
                number = 0; //no number, so just assign 0 to the list
                xValues.Add(number);
            }
         }
    
