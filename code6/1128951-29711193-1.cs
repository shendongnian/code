    public static void Main(string[] args)
    {
      MyClass.Method1(0, (MyClass.MyDelegate)((arg) =>
      {
        return 0;
      }));
      MyClass.Method1(0, DoSomething);
    }
    private static object DoSomething(object[] args = null)
    {
      return null;
    }
