    class myBase
    {
      private string _myProp;
      protected string MyProp
      { 
        get 
        {
          return _myProp;
        }
        set
        {
          _myProp = value;
        }
      }
    }
    class myChild : myBase
    {
      public myChild()
      {
        _myProp = "SomeString"; // This will fail!!!
        this.Myprop = "SomeString"; // This works
      }
    }
