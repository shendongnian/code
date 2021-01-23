        try
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                ...
                return myReturnDataSet;
            }
            else
            {
                return null;//Here it will sign you is not authenticated.
            }            
        }
        catch (Exception)
        {
            ...
            return myReturnDataSet;
        }
