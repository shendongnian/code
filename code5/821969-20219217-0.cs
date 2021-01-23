    class test
    {
      static bool test() {
        ...
      }
    
      private datetime prop;
    
      public datetime Prop
      {
        get { return prop; }
        set
        {
          if (test)
            prop = value;
          else
            // Ignore, throw exception, etc.
        }
      }
    }
