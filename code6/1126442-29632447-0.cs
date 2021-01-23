     class Stock
    {
        public int Value;
        public string Day;
    }
    Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add("Monday", 0);
            dic.Add("Tuesday", 1);
            dic.Add("Wednesday", 2);
            dic.Add("Thursday", 3);
            dic.Add("Friday", 4);
            var stocks = new Stock[]
                {
                    new Stock { Day = "Tuesday", Value= 10 },
                    new Stock { Day = "Monday", Value= 5 },
                };
            // result here
            var result = stocks.OrderBy(f => dic[f.Day]).ToArray();
     foreach (var item in result)
            {
                Console.WriteLine(item.Day);
                Console.WriteLine(item.Value);
            }
