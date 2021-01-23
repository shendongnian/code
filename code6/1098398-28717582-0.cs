    try
    {
        var existingUsers = Repo.GetAll(); // This may crash, and needs to be in a try
        if (existingUsers.Count > 0)
        {
          // Some code
        }
        return existingUsers;
    }
    catch (Exception)
    {
        throw new Exception("some error, don't bother");
    }    
