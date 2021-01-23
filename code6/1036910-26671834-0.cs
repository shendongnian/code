    using System;
    using System.Collections.Generic;
    namespace GenericsTest
    {
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }
        private void Run()
        {
            Dictionary<long, SpecialType1> a = new Dictionary<long, SpecialType1> {
            { 1, new SpecialType1 { BaseData = "hello", Special1 = 1 } },
            { 2, new SpecialType1 { BaseData = "goodbye", Special1 = 2 } } };
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
    public class BaseType
    {
        public string BaseData { get; set; }
    }
    public class SpecialType1 : BaseType
    {
        public int Special1 { get; set; }
    }
    }
