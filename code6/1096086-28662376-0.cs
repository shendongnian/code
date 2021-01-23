    using System;
    using System.Linq;
    using Reflection.IL;
    
    namespace StackOverflow
    {
        class Program
        {
            static void Main(string[] args)
            {
                var proxy = new Proxy();
                Invoker.invoke(proxy, p => p.formatSomething("Dumb test"));  
            }
        }
    
        public class Proxy
        {
            public string formatSomething(string input)
            {
    
                return String.Format("-===={0}====-", input);
            }
        }
    
        public static class Invoker
        {
            public static void invoke(Proxy proxy, Func<Proxy, string> online)
            {
                //Some caching logic that require the name of the method 
                //invoked on the proxy (in this specific case "formatSomething")    
                var methodName = online.GetCalledMethods().First().Name;
    
                Console.WriteLine(methodName);
            }
        }
    }
