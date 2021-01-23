      public void CompareWithParseInt()
      {
          int a = 1;
          string b = "1";
          bool isEqual = a == int.Parse(b);
      }
      public void CompareWithToString()
      {
          int a = 1;
          string b = "1";
          bool isEqual = a.ToString() == b;
      }
