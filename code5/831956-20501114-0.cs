    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    
    namespace ConsoleApplication1 {
    
        internal class Program {
    
            static void Main(string[] args) {
    
                var key = default(string);
                var value = default(string);
    
                var collection = new HashSet<KeyValuePair<string, string>>();
    
                for (var i = 0; i < 5000000; i++) {
    
                    if (key == null || i % 2 == 0) {
                        key = "k" + i;
                    }
                    value = "v" + i;
    
                    collection.Add(new KeyValuePair<string, string>(key, value));
                }
    
                var found = 0;
    
                var sw = new Stopwatch();
                sw.Start();
                for (var i = 0; i < 5000000; i++) {
    
                    if (collection.Contains(new KeyValuePair<string, string>("k" + i, "v" + i))) {
                        found++;
                    }
                }
                sw.Stop();
    
                Console.WriteLine("Found " + found);
                Console.WriteLine(sw.Elapsed);
                Console.ReadLine();
            }
        }
    }
