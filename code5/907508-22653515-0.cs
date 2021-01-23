    public string BitsToChar(string InpS)
    {
      string RetS = "";
      foreach (char c in InpS)
      {
         RetS = RetS + System.Convert.ToInt32(c);
      }
      return RetS;
    }
