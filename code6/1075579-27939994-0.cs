    public string InsertUserDetails(UserDetails userInfo)
    {
    
      if(null==userInfo)
        throw new Exception("userInfo is null");
    
      if(String.IsNullOrEmpty(userInfo.UserName))
        throw new Exception("UserName is null or empty");
    
      // and only after this check succeeds do the insert
    
    }
