    private IEnumerable<DateTime> getExpiredUsersDate()
    {
        try
        {
            using (SqlDataReader datareader = dal.getUsers())
            {
    
                while (datareader.Read())
                {
                    yield return (DateTime)datareader["DateAdded"];
    
                    MessageBox.Show(date.ToString());
                }
            }
        }
        catch (SqlException sqlex) { }
        catch (Exception ex) { }
    }
    
