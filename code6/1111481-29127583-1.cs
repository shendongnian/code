    public string remChar(string LicID)
    {
        if (LicID.Contains("."))
          {
            int index = LicID.IndexOf(".");
            return LicID.Substring(0, index);
          }
        
        return LicID;
    }
