    private static int GetIDFromProtectedID(string str)
    {
      int chkID;
      if(int.TryParse(str.Substring(40), out chkID))
      {
        string chkHash = chkID.ToString() + "this is my secret seed kjٵتשڪᴻᴌḶḇᶄ™∞ﮟﻑfasdfj90213";
        using(var sha = System.Security.Cryptography.SHA1.Create())
        {
          if(string.Join("", sha.ComputeHash(Encoding.UTF8.GetBytes(hashString)).Select(b => b.ToString("X2"))) == str.Substring(0, 40))
            return chkID;
        }
      }
      return 0;//or perhaps raise an exception here.
    }
