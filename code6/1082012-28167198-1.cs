      public int Index(IEnumerable<int> Selectedroles)
      {
        if (Selectedroles == null)
           { return 0; }
        else
        {
          var arr = Selectedroles.ToArray();
            int result = 0;
           for (int i = 0; i < arr.Length; i++)
            {
                result += Convert.ToInt32(arr[i]);
            }
         return result;
      }
