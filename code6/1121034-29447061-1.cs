    static void Main(string[] args)
    {
        IList<MoneyTable> money = new List<MoneyTable>();
        money.Add(new MoneyTable { Money = 10, Name = "aaa" });
        money.Add(new MoneyTable { Money = 5, Name = "bbb" });
        money.Add(new MoneyTable { Money = 15, Name = "ccc" });
        money.Add(new MoneyTable { Money = 15, Name = "ddd" });
        decimal totalSum = 0;
        var query = from m in money
                    select new { Name = m.Name, Money = m.Money, Sum = (totalSum = totalSum + m.Money) };
        Console.WriteLine("{0}\t{1}\t{2}", "Name", "Money", "Sum");
        foreach (var item in query)
        {
            Console.WriteLine("{0}\t{1}\t{2}", item.Name, item.Money, item.Sum);
        }
        Console.ReadLine();
    }
