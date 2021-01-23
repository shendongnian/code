    try
    {
        var di = new DirectoryInfo(path);
        if(di.Exists)
        {
            //The directory exists
        }
        else
        {
            //The path is valid, but does not exist.
        }
    }
    catch(Exception e)
    {
        //The path is invalid or user does not have access.
    }
