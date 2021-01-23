    // Change return type to a list of DateTime's
    private List<DateTime> getExpiredUsersDate()
    {
        // Don't need this
        //DateTime date = new DateTime();
        
        var dates = new List<DateTime>();
    
        try
        {
            using (SqlDataReader datareader = dal.getUsers())
            {
                while (datareader.Read())
                {
                    // Add the date to the list.
                    dates.Add((DateTime)datareader["DateAdded"]);
    
                    MessageBox.Show(date.ToString());
                }
            }
        }
        catch (SqlException sqlex) 
        { 
            // You should really do something here for debugging purposes
        }
        catch (Exception ex) 
        { 
            // You should really do something here for debugging purposes
        }
    
        // Return all dates.
        return dates;
    }
    
