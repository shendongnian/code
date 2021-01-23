    ICollection existingUsers; 
    try
    {
        existingUsers = Repo.GetAll(); // This may crash, and needs to be in a try
    }
    catch (Exception)
    {
        throw new Exception("some error, don't bother");
    }  
    if (existingUsers.Count > 0)
    {
        //some code
    }
