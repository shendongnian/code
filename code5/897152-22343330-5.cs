    using System;
    using System.IO;
    using System.Reflection;
    namespace ClientApp
    {
        class FakeClass
        {
            public int SomeProperty { get { return 0; } }
            public string SomeMethod()
            {
                return "Library not exists, so we used stub! :)";
            }
        }
        class Program
        {
            // dynamic instance of Real or Fake class
            private static dynamic RealOfFakeObject;
            static void Main(string[] args)
            {
                TryLoadAssembly();
                Console.WriteLine(RealOfFakeObject.SomeMethod());
                Console.WriteLine(RealOfFakeObject.SomeProperty);
                Console.WriteLine("Press any key...");
                Console.ReadKey();
            }
            private static void TryLoadAssembly()
            {
                string assemblyFullName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RealAssembly.dll");
                if (File.Exists(assemblyFullName))
                {
                    var RealAssembly = Assembly.LoadFrom(assemblyFullName);
                    var RealClassType = RealAssembly.GetType("RealAssembly.RealClass");
                    RealOfFakeObject = Activator.CreateInstance(RealClassType);
                }
                else
                {
                    RealOfFakeObject = new FakeClass();
                }
            }
        }
    }
