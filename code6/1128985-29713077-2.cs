    using System;
    
    namespace so29713053
    {
        class Program
        {
            static void Main(string[] args)
            {
                string version = "0.0.2";
    
                Console.WriteLine("Checking if version match 0.0.1");
                if (version == "0.0.1")
                {
                    Console.WriteLine("  version match");
                }
                else
                {
                    Console.WriteLine("  version doesn't match");
                }
    
    
                Console.WriteLine("\nChecking if version match 0.0.2");
                if (version == "0.0.2")
                {
                    Console.WriteLine("  version match");
                }
                else
                {
                    Console.WriteLine("  version doesn't match");
                }
    
                Console.WriteLine("\nCheck version using string.compare...");
                switch (string.Compare(version, "0.0.1"))
                {
                    case 0:
                        Console.WriteLine("   version match");
                        break;
    
                    case 1:
                        Console.WriteLine("   version is newer");
                        break;
    
                    case -1:
                        Console.WriteLine("   version is older");
                        break;
                }
    
                // or you can go deep - code need error checking
                string[] parts = version.Split('.');
                string major = parts[0];
                string minor = parts[1];
                string revision = parts[2];
    
                // compare each parts of the version number
                Console.ReadLine();
            }
        }
    }
