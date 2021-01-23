    using System;
    using System.Collections.Generic;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Person p = new Person() { FirstName ="a", MiddleName = "b", LastName = "c" };
                List<string> result = new List<string>();
                string[] enums = Enum.GetNames(typeof(PersonProperties));
                foreach(string e in enums)
                {
                    result.Add(p.GetType().GetProperty(e).GetValue(p, null).ToString());
                }
                int i = 0;
                foreach (string e in enums)
                {
                    Console.WriteLine(string.Format("{0} : {1}", e, result[i++]));
                }
                Console.ReadKey(false);
            }
        }
        public class Person
        {
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
        }
        public enum PersonProperties
        {
            FirstName = 1,
            MiddleName = 2,
            LastName = 3
        }
    }
