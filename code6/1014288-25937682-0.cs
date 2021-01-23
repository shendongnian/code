    public interface IWithMethod
    {
      void MyMethod()
    }
    public class MyClass : IWithMethod
    {
      public void MyMethod()
      {
      }
    }
    public static IEnumerable<T> MyMethod(this IEnumerable<T> lst)
      where T : IWithMethod
    {
      return lst.Select(n => n.MyMethod());
    }
