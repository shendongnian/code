    public class ListStuff
    {
        public int Count { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public int LType { get; set; }
        public int Group { get; set; }
    }
    var query = Enumerable.Range(0, 1440).Select((n, index) =>
                {
                    if ((index >= 480 && index <= 749) || (index >= 810 && index <= 999) || (index >= 1080 && index <= 1099) || (index >= 1200 && index <= 1299))
                        return 0;
                    else if ((index >= 750 && index <= 809) || (index >= 1100 && index <= 1199))
                        return 1;
                    else
                        return 2;
                });
            int typeCount = 0;
            int groupCount = 0;
            var result = query
                   .Select((x, i) => new
                   {
                       Value = x,
                       Index = i,
                       Group = (((i == 0 || (query.ElementAt(i - 1) == 2)) && x != 2) ? ++groupCount : groupCount)
                   })
                   .GroupBy(x =>
                       x.Index == 0 || x.Value != query.ElementAt(x.Index - 1)
                           ? ++typeCount
                           : typeCount)
                   .Select(x => new ListStuff()
                   {
                       Count = x.Count(),
                       Start = x.First().Index,
                       End = x.Last().Index,
                       LType = x.First().Value,
                       Group = x.First().Group
                   })
                   .Where(x => x.LType == 0 || x.LType == 1)
                   .GroupBy(x => x.Group)
                   .ToList();
