    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Experimentos {
        class Program {
            static void Main(string[] args) {
                var array = new[] { "one", "two", "three" };
                var list = new List<string> { "four", "five", "six" };
                var dictionary = new Dictionary<string, string> {
                    {"k1", "v1"},
                    {"k2", "v2"},
                    {"k3", "v2"},
                };
    
                Console.WriteLine(GetString(array));
                Console.WriteLine(GetString(list));
                Console.WriteLine(GetString(dictionary));
    
                Console.ReadLine();
            }
    
            public static string GetString<T>(IEnumerable<T> value) {
                return "["
                    + string.Join(", ", value)
                    + "]";
            }
    
            public static string GetString<TKey, TValue>(Dictionary<TKey, TValue> value) {
                return "{"
                    + string.Join(", ", value.Select(entry => entry.Key + " : " + entry.Value))
                    + "}";
            }
        }
    }
