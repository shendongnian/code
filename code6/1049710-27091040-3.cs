    public enum EnumFoo
    {
      Foo1, Foo2
    }
    public enum EnumBar
    {
      Bar1, Bar2
    }
    public void Main()
    {
      foreach (var value in GetValues<EnumFoo>())
        Console.WriteLine(value); // Foo1 Foo2
      foreach (var value in GetValues<EnumBar>())
        Console.WriteLine(value); // Bar1 Bar2
    }
