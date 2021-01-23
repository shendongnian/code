    public/protected string methodname()
    {
      string strVariable = "";
   
      try
      {
        strVariable = "No Error";
      }
      catch(Exception EX)
      {
        strVariable = "Error";
      }
      return strVariable ;
    }
