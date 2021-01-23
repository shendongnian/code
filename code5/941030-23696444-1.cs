    public class CountStuff
    {
        public int Count { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public int Type { get; set; }
        public int Group { get; set; }
    }
    public IEnumerable<CountStuff> GetContinuousList(int checkNum, IEnumerable<int> query)
    {
        int groupCount = 0;
        var result = query
           .Select((x, i) => new { Value = x, Index = i })
           .SkipWhile(x => x.Value != checkNum)                   // Skip until first 0 is reached
           .TakeWhile(x => x.Value == checkNum || x.Value != checkNum)   // Take a continuous series of checkNum
           .Where(x => x.Value == checkNum)                       // Filter only checkNum
           .GroupBy(x =>
               // Treat as a new group if it's:
               // 1) the 1st element, or
               // 2) doesn't equal to previous number
               x.Index == 0 || x.Value != query.ElementAt(x.Index - 1)
                   ? ++groupCount
                   : groupCount)
           .Select(x => new CountStuff()
           {
               Count = x.Count(),
               Start = x.First().Index,
               End = x.Last().Index,
               Type = checkNum
           });
        return result;
    }
    List<CountStuff> cntList = new List<CountStuff>();
    for (int d = 0; d < 10; d++) //whatever range of numbers you are looking for
        cntList.AddRange(GetContinuousList(d, query));
    int GroupTest = 0;
    foreach (CountStuff t in cntList.OrderBy(x => x.Start))
    {
        if (t.Type == 2)
        {
            //New Group
            Grouptest++;
        }
        t.Group = Grouptest;
    }
