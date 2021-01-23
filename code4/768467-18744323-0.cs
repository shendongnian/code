    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace UnitTest
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                BugManagerQueryOptions bmqo = new BugManagerQueryOptions
                {
                    Id = 64,
                    Header = "This is a header, that has not been set by reflection (yet)",
                    Description = "This is a description that has not been set by reflection (yet)"
                };
    
                var pairs = "Id=23||Header=This is a header||Description=This is a description"
                    .Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(q => new KeyValuePair<string, string>(q.Split('=')[0], q.Split('=')[1]));
    
                // TEST : Getting values from the BugManagerQueryOptions instance (bmqo)
                foreach (KeyValuePair<string, string> pair in pairs)
                {
                    Console.WriteLine(typeof(BugManagerQueryOptions).GetProperty(pair.Key).GetValue(bmqo, null));
                }
    
                // TEST : Setting values to the BugManagerQueryOptions instance (bmqo)
                foreach (KeyValuePair<string, string> pair in pairs)
                {
                    if (typeof(BugManagerQueryOptions).GetProperty(pair.Key).PropertyType == typeof(Int32))
                    {
                        typeof(BugManagerQueryOptions).GetProperty(pair.Key).SetValue(bmqo, Int32.Parse(pair.Value), null);
                    }
                    else
                    {
                        typeof(BugManagerQueryOptions).GetProperty(pair.Key).SetValue(bmqo, pair.Value, null);
                    }
                }
    
                // TEST: Getting values from the BugManagerQueryOptions instance (bmqo) AFTER being set by reflection
                foreach (KeyValuePair<string, dynamic> pair in pairs)
                {
                    Console.WriteLine(typeof(BugManagerQueryOptions).GetProperty(pair.Key).GetValue(bmqo, null));
                }
    
                Console.Read();
            }
        }
    
        public class BugManagerQueryOptions
        {
            public Int32 Id { get; set; }
            public String Header { get; set; }
            public String Description { get; set; }
        }
    }
