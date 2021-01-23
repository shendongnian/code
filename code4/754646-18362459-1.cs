    namespace ConsoleApplication1
    {
        using System;
        using System.Reflection;
    
        class Program
        {
            static void Main(string[] args)
            {
                var DLL = Assembly.LoadFile(@"C:\visual studio 2012\Projects\ConsoleApplication1\ConsoleApplication1\DLL.dll");
    
                foreach(Type type in DLL.GetExportedTypes())
                {
                    dynamic c = Activator.CreateInstance(type);
                    c.Output(@"Hello");
                }
    
                Console.ReadLine();
            }
        }
    }
