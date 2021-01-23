    try
        {
            session.Save(obj);
            return true;
        }
        catch(Exception e)
        {
            throw e; //Throws exception to calling method
            return false;  //this will be flagged as unreachable code
        }
