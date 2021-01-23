    public void Main()
    { 
      x = 52;
      
      var d = (Action)Test;
      var d2 = (Action)Delegate.CreateDelegate(typeof(Action), new UserQuery(), d.Method);
      
      d();
      d2();
    }
    
    int x = 42;
    
    public void Test()
    {
      x.Dump();
    }
