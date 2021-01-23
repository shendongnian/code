    using System.IO;
    using System;
    using System.Reflection;
    using System.Linq;
    class Program
    {
        static void Main()
        {
            Assembly a = typeof(Program).Assembly;
        
            var types = a.GetTypes().Where(i=>i.IsSubclassOf(typeof(T)));
        
            foreach(var i in types)
            {
                Console.WriteLine(i);
            }
        }
    }
    public class T {  }
    public class TT : T {  }
    public class TTT : T {  }
