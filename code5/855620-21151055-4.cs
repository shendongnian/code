    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    
    public class mainClass
    {
        public static void Main(string[] args)
        {
            new List<Type> { typeof(StringBuilder), typeof(Int64) }.ForEach(x =>
            {
                dynamic instance = Activator.CreateInstance(x);
    
                DoSomething(instance);
            });
    
            Console.ReadKey();
        }
    
        public static void DoSomething(StringBuilder stringBuilder)
        {
            Console.WriteLine("StringBuilder overload");
        }
    
    
        public static void DoSomething(Int64 int64)
        {
            Console.WriteLine("Int64 overload");
        }
    }
