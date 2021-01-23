    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            List<Record> input = new List<Record>();
            input.Add(new Record { CheckNumber = 100, Step = "Book", Amount = 100 });
            input.Add(new Record { CheckNumber = 100, Step = "Bank", Amount = 100 });
            input.Add(new Record { CheckNumber = 100, Step = "Account", Amount = 100 });
            input.Add(new Record { CheckNumber = 101, Step = "Book", Amount = 75 });
            input.Add(new Record { CheckNumber = 101, Step = "Bank", Amount = 75 });
            List<ExpandoObject> results = GetPivotRows(input);
            //test
            for (int i = 0; i < results.Count; i++)
            {
                dynamic record = results[i];
                Console.WriteLine("{0} - {1} - {2} - {3}", record.CheckNumber, record.Book, record.Bank, record.Account);
            }
        }
        public static List<ExpandoObject> GetPivotRows(List<Record> input)
        {
            List<string> steps = input.Select(e => e.Step).Distinct().ToList();
            Dictionary<int, ExpandoObject> outputMap = new Dictionary<int,ExpandoObject>();
            for (int i = 0; i < input.Count; i++)
            {
                dynamic row;
                if(outputMap.ContainsKey(input[i].CheckNumber))
                {
                    row = outputMap[input[i].CheckNumber];
                }
                else
                {
                    row = new ExpandoObject();
                    row.CheckNumber = input[i].CheckNumber;
                    outputMap.Add(input[i].CheckNumber, row);
                    // Here we're initializing all the possible "Step" columns
                    for (int j = 0; j < steps.Count; j++)
                    {
                        (row as IDictionary<string, object>)[steps[j]] = new Nullable<int>();
                    }
                }
                (row as IDictionary<string, object>)[input[i].Step] = input[i].Amount;
            }
            return outputMap.Values.OrderBy(e => ((dynamic)e).CheckNumber).ToList();
        }
    }
    public class Record
    {
        public int CheckNumber { get; set; }
        public string Step { get; set; }
        public decimal Amount { get; set; }
    }
