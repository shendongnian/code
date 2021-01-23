    public void Main()
    {
      var a = new A();
      var b = new B();
      var c = new C();
      a.SomethingChanged += b.OnSomethingChanged;
      a.SomethingChanged += c.OnSomethingChanged;
      a.RaiseSomethingChangedEvent();
    }
    private class A
    {
      public event EventHandler SomethingChanged;
      public void RaiseSomethingChangedEvent()
      {
        if(SomethingChanged !=null)
          SomethingChanged(this, new EventArgs());
      }
    }
    private class B
    {
      public void OnSomethingChanged(object sender, EventArgs e)
      {
        Console.WriteLine("B: Event was raised.");
      }
    }
    private class C
    {
      public void OnSomethingChanged(object sender, EventArgs e)
      {
        Console.WriteLine("C: Event was raised.");
      }
    }
