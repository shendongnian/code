    [WebMethod]
    public string Verify(string user,string pass)
    {
      //DataTable dt = YourMethod_ReturningDataTable(); 
      //retrun dt.toJson();
      //But in your case 
      bool IsAllowedtoLogin = true;
      return IsAllowedtoLogin.toJson(); 
    }
