    using System;
    namespace Demo
    {
        public class MyClass // Use a non-generic base class for the non-generic bits.
        {
            public const string MyConstant = "fortytwo";
            public static string MyString()
            {
                return MyConstant;
            }
        }
        public class MyClass<T>: MyClass // Derive the generic class
        {                                // from the non-generic one.
            public void Test(T item)
            {
                Console.WriteLine(MyConstant);
                Console.WriteLine(item);
            }
        }
        public static class Program
        {
            private static void Main()
            {
                Console.WriteLine(MyClass.MyConstant);
                Console.WriteLine(MyClass.MyString());
            }
        }
    }
