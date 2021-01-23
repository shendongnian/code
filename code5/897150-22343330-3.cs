    namespace ClientApp
    {
        using System;
        using System.IO;
        using System.Reflection;
        class Program
        {
            // dynamic instance of Real or Fake class
            private static dynamic OurOrUniversityObject;
            static void Main(string[] args)
            {
                TryLoadAssembly();
                Console.WriteLine(OurOrUniversityObject.SomeMethod());
                Console.WriteLine(OurOrUniversityObject.SomeProperty);
                Console.WriteLine("Press any key..");
                Console.ReadKey();
            }
            private static void TryLoadAssembly()
            {
                string assemblyFullName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UniversityAssembly.dll");
                if (File.Exists(assemblyFullName))
                {
                    var RealAssembly = Assembly.LoadFrom(assemblyFullName);
                    var RealClassType = RealAssembly.GetType("UniversityAssembly.RealClass");
                    OurOrUniversityObject = Activator.CreateInstance(RealClassType);
                }
                else
                {
                    OurOrUniversityObject = new FakeClass();
                }
            }
        }
        
        class FakeClass
        {
            public int SomeProperty { get { return 0; } }
            public string SomeMethod()
            { 
                return "Library not exists, so we used stub! :)";
            }
        }
    }
