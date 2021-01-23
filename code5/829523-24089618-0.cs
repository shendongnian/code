    public void SetupDisosableThing(IDisposable foo)
    {
     foo.Bar = "baz";
    }
    
    void Main()
    {
      using (var x = new Thing())
      {
       SetupDisposableThing(x);
      }
    }
        
