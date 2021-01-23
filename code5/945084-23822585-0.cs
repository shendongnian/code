      PIDages.Sort();
      lollist.WriteLine();
      string sResult = string.Empty;
      foreach (int a in PIDages)
      {
          sResult += (a + "  ");   
      }
      lollist.Write(sResult.Trim());
    
      PIDages.Clear();
