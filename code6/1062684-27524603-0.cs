    static void Main(string[] args)
    {
       List<string> firstList = new List<string>();
       firstList.Add("AA");
       firstList.Add("BB");
       firstList.Add("CC");
       List<int> secondList = new List<int>();
       secondList.Add(1);
       secondList.Add(2);
       var lstFinal = (from f1 in firstList
                       from f2 in secondList
                       select new { f1, f2 }).ToList();
       foreach (var s in lstFinal)
       {
           Console.WriteLine(s.f1 + " " +s.f2);
       }
       Console.Read();
    }
