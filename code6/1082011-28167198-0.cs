      public int Index(IEnumerable<int> Selectedroles)
      {
        if (Selectedroles == null)
           { return 0; }
        else
        {
            int result = 0;
           for (int i = 0; i < Selectedroles.Count(); i++)
            {
                result += Convert.ToInt32(Selectedroles[i]);
            }
         return result;
      }
