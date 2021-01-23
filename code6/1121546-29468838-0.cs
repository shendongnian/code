    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main()
            {
                List<string> keys = new List<string>
                {
                    "REPORTMONTH",
                    "CONTRACT", "DATE", "AMOUNT",
                    "CONTRACT", "DATE", "AMOUNT"
                };
                List<string> values = new List<string>
                {
                    "01",
                    "ABC123", "01022014", "300.00",
                    "DEF345", "03042014", "400.00"
                };
                var combined = Enumerable.Zip(
                    keys, values, (key, value) => new { Key = key, Value = value})
                    .ToLookup(entry => entry.Key);
                var dicts = new []
                {
                    new Dictionary<string, string>(),
                    new Dictionary<string, string>()
                };
                foreach (var items in combined)
                {
                    if (items.Count() == 1)
                    {
                        var value = items.First().Value;
                        dicts[0][items.Key] = value;
                        dicts[1][items.Key] = value;
                    }
                    else
                    {
                        int count = 0;
                        foreach (var item in items.Take(2))
                            dicts[count++][item.Key] = item.Value;
                    }
                }
                dump("1st dictionary", dicts[0]);
                dump("2nd dictionary", dicts[1]);
            }
            static void dump(string title, Dictionary<string, string> data)
            {
                Console.WriteLine(title);
                foreach (var item in data)
                    Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
                Console.WriteLine();
            }
        }
    }
