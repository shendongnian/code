    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace LinqPlayground
    {
        class Program
        {
            public class UniqueChecker<T>
            {
                public bool HasUnique<T>(Func<T, object> property, IEnumerable<T> entities)
                {
                    var uniqueDict = new Dictionary<object, bool>();
                    foreach (var entity1 in entities)
                    {
                        var key = property(entity1);
                        if (uniqueDict.ContainsKey(key))
                        {
                            uniqueDict[key] = false;
                        }
                        else
                        {
                            uniqueDict.Add(key, true);
                        }
                    }
                    return uniqueDict.Values.All(b => b);
                }
            }
    
            public class Person
            {
                public string Name { get; set; }
            }
    
            static void Main(string[] args)
            {
                var people = new List<Person>
                {
                    new Person {Name = "Chris"},
                    new Person {Name = "Janet"},
                    new Person {Name = "John"},
                    new Person {Name = "Janet"},
                };
    
                var checker = new UniqueChecker<Person>();
    
    
                Console.WriteLine("Are names unique? {0}",checker.HasUnique(person => person.Name, people));
            }
        }
    }
