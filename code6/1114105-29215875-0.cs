    Message ret = new Message();
    try
    {}
    catch (Exception e)
    {
        ret.ErrorPropertyOfTypeString = e.Message;
    }
    return ret;
    
    
    Message ret = new Message();
    try
    {}
    catch (Exception e)
    {
        throw new Exception("My custom message here", e);
    }
    return ret;
