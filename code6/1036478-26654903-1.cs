    class L
    {
      public bool GetSettings(IQProvider qProvider)
      {
          return qProvider.Q.Equals("BLAH");
      }
    }
