    public DateTime GetCurrentDateTime()
    {
       bool haveAccess = AccessRules.Any(c => c == "GetCurrentDateTime");
       if (haveAccess)
       {
          return DateTime.Now;
       }
       return null;
    }
