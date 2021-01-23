    public object returnObject(string user, string pwd)
    {
        if(checkCredentials(user,pwd))
        return new QRcode(usr,pwd);
    
        else 
        return false;
    }
