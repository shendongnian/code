    using System;
    using System.Linq;
    using ClassLibraryAssembly;
    using OtherAssemblyX;
    
    // This is a faking attribute, with same signature of that in unavailable assembly.
    namespace OtherAssemblyY
    {
        public class YAttribute : Attribute
        {
        }
    }
    
    namespace MainAssembly
    {
        class Program
        {
            static void Main(string[] args)
            {
                var type = typeof (SomeType);
    
                AppDomain.CurrentDomain.AssemblyResolve += (sender, eventArgs) =>
                {
                    if (eventArgs.Name == "OtherAssemblyY, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")
                        return typeof(Program).Assembly;
                    return null;
                };
    
                Console.WriteLine(type.IsDefined(typeof (XAttribute), true));
    
                foreach (var attrObject in type.GetCustomAttributes(true))
                {
                    Console.WriteLine("Attribute found: {0}, Assembly: {1}", attrObject, attrObject.GetType().Assembly);
                }
            }
        }
    }
