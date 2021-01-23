    // Change return type to a list of DateTime's
    private List<DateTime> getExpiredUsersDate()
    {
        // Don't need this
        //DateTime date = new DateTime();
        
        var dates = new List<DateTime>();
    
        // The try-catch is unnecessary, 
        // the using-statement will catch all exceptions before the try-catch.
        //try
        //{
            using (SqlDataReader datareader = dal.getUsers())
            {
                while (datareader.Read())
                {
                    // Add the date to the list.
                    dates.Add((DateTime)datareader["DateAdded"]);
    
                    MessageBox.Show(date.ToString());
                }
            }
        //}
        //catch (SqlException sqlex) { }
        //catch (Exception ex) { }
    
        // Return all dates.
        return dates;
    }
    
