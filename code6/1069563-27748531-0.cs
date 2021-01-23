    [Pure]
    public delegate int F(int i);
    public class A
    {
      public void f(F f)
      {
        var i = f(1);
        Contract.Assert(i == f(1));
      }
    }
