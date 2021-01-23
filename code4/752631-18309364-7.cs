    private IEnumerable<DateTime> getExpiredUsersDate()
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
    
