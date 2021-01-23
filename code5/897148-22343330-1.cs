    using System;
    using System.IO;
    using System.Reflection;
    namespace ClientApp
    {
        /// <summary>
        /// Entry Point Class
        /// </summary>
        class Program
        {
            static void Main(string[] args)
            {
                var obj = new FakeUniversityAssemblyClass();
                Console.WriteLine(obj.SomeMethod());
                Console.ReadKey();
            }
        }
        /// <summary>
        /// Fake assembly whitch used as replacement class
        /// </summary>
        class FakeUniversityAssemblyClass
        {
            private bool AssemblyLoaded;
            private dynamic RealInstance;
            /// <summary>
            /// Constructor. Load assembly if it exists on disk
            /// </summary>
            public FakeUniversityAssemblyClass()
            {
                string assemblyFullName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UniversityAssembly.dll");
                // if assembly exists
                if (File.Exists(assemblyFullName))
                {
                    // load assembly
                    var UniversityAssembly = Assembly.LoadFrom(assemblyFullName);
                    // find class by full path(with namespace)
                    var RealUniversityAssemblyClass = UniversityAssembly.GetType("UniversityAssembly.UniversityAssemblyClass");
                    // and assign new object to dynamic-type object
                    RealInstance = Activator.CreateInstance(RealUniversityAssemblyClass);
                    AssemblyLoaded = true;
                }
                else
                    AssemblyLoaded = false;
            }
            public int SomeProperty
            {
                get 
                {
                    if (AssemblyLoaded)
                        return RealInstance.SomeProperty;
                    else
                        return 0;
                }
                set
                {
                    if (AssemblyLoaded)
                        RealInstance.SomeProperty = value;
                    // else don't set anything
                }
            }
            public string SomeMethod()
            {
                if (AssemblyLoaded)
                    return RealInstance.SomeMethod();
                else
                    return "Library not exists, so we used stub! :)";
            }
        }
    }
