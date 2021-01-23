    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using System.Linq;
    
    public class mainClass
    {
        public static void Main(string[] args)
        {
            new List<Type> { typeof(StringBuilder), typeof(Int64) }.ForEach(x =>
            {
                var methodInfoArray = typeof(mainClass).GetMethods();
                var methodInfo = methodInfoArray.First(mi => mi.Name == "DoSomething" && mi.IsGenericMethodDefinition);
                var genericMethod = methodInfo.MakeGenericMethod(new Type[] { x });
                var blah = genericMethod.Invoke(null, new object[] { "Hello" }) as MethodInfo;
            });
    
            Console.ReadKey();
        }
    
        public static void DoSomething<T>(string variable)
        {
            Console.WriteLine("DoSomething<T> " + typeof(T) + " overload - " + variable);
        }
    
        public static void DoSomething(string variable)
        {
            Console.WriteLine("DoSomething - " + variable);
        }
    
    }
