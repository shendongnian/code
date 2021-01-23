    public class ClassBase
    {
      private string _name;
      public string Name 
      { 
        get 
        { 
          CallMethod();
          return _name;
        }
        set
        {
          _name = value;
        }
      }
    }
