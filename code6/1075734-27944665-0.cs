    using System;
    using System.Reflection;
    namespace Demo
    {
        public class OuterClass
        {
            protected class NestedClass
            {
                private string myVar;
                private NestedClass(){} // Commenting-out this line will cause the reflection to break.
                public NestedClass(string myVar)
                {
                    this.myVar = myVar;
                }
            }
        }
        public class MyDerivedClass: OuterClass
        {
            public MyDerivedClass()
            {
                Type type = typeof(NestedClass);
                var ctor = type.GetConstructor(BindingFlags.Instance|BindingFlags.NonPublic, null, Type.EmptyTypes, null);
                var nested = (NestedClass) ctor.Invoke(null);
                Console.WriteLine(nested);
            }
        }
        public static class Program
        {
            private static void Main()
            {
                var test = new MyDerivedClass();
            }
        }
    }
