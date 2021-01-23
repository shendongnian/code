    private void removeExpiredUsers()
    {
        var toRemove = getExpiredUsersDate()
            .Where(date => DateTime.Now >= date.AddMinutes(2));
            
        foreach (var date in toRemove)
        {
            dal.spDeleteExpiredUsers(date);
        }
    }
    
