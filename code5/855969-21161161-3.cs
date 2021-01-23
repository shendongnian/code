    private static bool GetIDFromProtectedID(string str, out int id)
    {
      int chkID;
      if(int.TryParse(str.Substring(40), out chkID))
      {
        using(var sha = System.Security.Cryptography.SHA1.Create())
        {
          if(string.Join("", sha.ComputeHash(Encoding.UTF8.GetBytes(chkID.ToString() + Seed)).Select(b => b.ToString("X2"))) == str.Substring(0, 40))
    	  {
    	    id = chkID;
    		return true;
    	  }
        }
      }
      id = 0;
      return false;
    }
