    public user isValidUser(string username, string userPassword, out LoginStatus loginStatus)
    {
    ...
    }
    enum LoginStatus
    {
      success,
      badPassword,
      badUsername
    }
