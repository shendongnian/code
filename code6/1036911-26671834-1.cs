    namespace GenericsTest
    {
    using System;
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
            Console.In.ReadLine();
        }
        private void Run()
        {
            Dictionary<long, Foo> a = new Dictionary<long, Foo> {
                { 1, new Foo { BaseData = "hello", Special1 = 1 } },
                { 2, new Foo { BaseData = "goodbye", Special1 = 2 } } };
            Test(a);
        }
        void Test<Y>(Dictionary<long, Y> data) where Y : BaseType
        {
            foreach (BaseType x in data.Values)
            {
                Console.Out.WriteLine(x.BaseData);
            }
        }
    }
    public class BaseType { public string BaseData { get; set; } }
    public class Foo : BaseType { public int Special1 { get; set; } }
    public class Bar : BaseType { public int Special1 { get; set; } }
    }
