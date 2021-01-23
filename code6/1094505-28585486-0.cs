    public class A : Base { }
    public class B : Base { }
    public static class BaseExtensions
    {
        public static T GetAsT<T>(this Base base)  where T: Base
        {
           return (T)base;
        }
    }
    public static void Main() 
    {
        Base obj = new A();
        B b = obj.BaseAsT<B>(); // This compiles but causes an exception
    }
