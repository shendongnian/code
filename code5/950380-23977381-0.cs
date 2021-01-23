    public class MyGenericClass<T> where T : new()
    {
    }
    public class MyClass
    {
        public MyClass()
        {
        }
    }
    public class MyClass2
    {
        public MyClass2(int i)
        {
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // OK!
            MyGenericClass<MyClass> c1 = new MyGenericClass<MyClass>();
            // Gives the error:
            // 'MyClass2' must be a non-abstract type with a public parameterless
            // constructor in order to use it as parameter 'T' in the generic type
            // or method 'MyGenericClass<T>'
            MyGenericClass<MyClass2> c2 = new MyGenericClass<MyClass2>();
        }
    }
