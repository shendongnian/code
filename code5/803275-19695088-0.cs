    using System;
    using System.Linq;
    
    namespace Stuff
    {
        class Program
        {
            static void Main(string[] args)
            {
                string enumName = "Colors";
                string value = "Red";
    
    
                var loadedPublicTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetExportedTypes());
                var possibleEnums = loadedPublicTypes.Where(x => x.IsEnum && x.Name == enumName);
                
                foreach (var e in possibleEnums)
                {
                    Console.WriteLine("{0} is{1} a member of {2}", value, Enum.GetNames(e).Contains(value) ? "" : " not", e.FullName);
                }
    
            }
    
            
        }
        public enum Colors
        {
            Red,
            Yellow
        }
    }
