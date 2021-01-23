    using System;
    
    class Program
    {
        class Test
        {
            public int DoSomething() { return 1; }
        }
    
        struct TestStruct
        {
            public int DoSomething() { return 2; }
        }
    
        static void Main(string[] args)
        {
            var method = typeof(Test).GetMethod("DoSomething");
            var getter = method.CreateGetter<object, int>();
            Console.WriteLine(getter(new Test()));
    
            var method2 = typeof(TestStruct).GetMethod("DoSomething");
            var getter2 = method2.CreateGetter<object, int>();
            Console.WriteLine(getter2(new TestStruct()));
    
            Console.ReadKey();
        }
    }
