    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Dynamic;
    
    namespace ConsoleApplication11
    {
        class KeyAttribute : Attribute
        {
        }
        public class Example
        {
            [Key]
            public Guid FirstKey { get; set; }
    
            [Key]
            public Guid SecondKey { get; set; }
    
            public int UnimportantField { get; set; }
        }
    
        static class Program
        {
            static void Main(string[] args)
            {
                Example e = new Example()
                {
                    FirstKey = Guid.NewGuid(),
                    SecondKey = Guid.NewGuid()
                };
    
                var func = e.GetKeyFunction<Example>();
    
                var key = func(e);
                Console.WriteLine(key.FirstKey);
                Console.WriteLine(key.SecondKey);
            }
    
            public static Func<T, dynamic> GetKeyFunction<T>(this T source)
            {
                return (t) =>
                    {
                        var dyn = (IDictionary<string, object>)new ExpandoObject();
                        foreach (var p in GetKeyProperties(typeof(T)))
                        {
                            dyn.Add(p.Name, p.GetValue(source));
                        }
                        return dyn;
                    };
            }
    
            public static IEnumerable<PropertyInfo> GetKeyProperties(Type t)
            {
                PropertyInfo[] properties = t.GetProperties();
                return properties.Where(p => p.GetCustomAttributes<KeyAttribute>().Any());
            }
        }
    }
