    using System;
    using System.Linq;
    using System.Reflection;
    
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                typeof(Test).GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                    .OrderBy(member => member.MetadataToken).ToList()
                    .ForEach( member => Console.WriteLine(member.Name));
    
                Console.ReadLine();
            }
        }
    
        public class Test
        {
            public int SecondProperty { get; set; }
            public int FirstProperty { get; set; }
    
        }
    }
