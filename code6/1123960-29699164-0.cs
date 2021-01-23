      public class Interval
        {
            public int Start { get; set; }
            public int End { get; set; }
        };
        enum Node
        {
            Unvisited = 0,
            Visited = 1,
            Used = 2
        };
        Node[] tree;
        public void Calculate()
        {
            var secondryIntervalsAsDates = new List<Tuple<DateTime,DateTime>> { new Tuple<DateTime, DateTime>( new DateTime(2015, 03, 15, 4, 0, 0), new DateTime(2015, 03, 15, 5, 0, 0))};
            var mainInvtervalAsDate = new Tuple<DateTime, DateTime>(new DateTime(2015, 03, 15, 3, 0, 0), new DateTime(2015, 03, 15, 7, 0, 0));
            // calculate biggest interval
            var startDate = secondryIntervalsAsDates.Union( new List<Tuple<DateTime,DateTime>>{mainInvtervalAsDate}).Min(s => s.Item1).AddMinutes(-1);
            var endDate = secondryIntervalsAsDates.Union(new List<Tuple<DateTime, DateTime>> { mainInvtervalAsDate }).Max(s => s.Item2);
            var mainInvterval = new Interval { Start = (int)(mainInvtervalAsDate.Item1 - startDate).TotalMinutes, End = (int)(mainInvtervalAsDate.Item2 - startDate).TotalMinutes };
            var wholeInterval = new Interval { Start = 1, End = (int)(endDate - startDate).TotalMinutes};
            //convert intervals to minutes
            var secondaryIntervals = secondryIntervalsAsDates.Select(s => new Interval { Start = (int)(s.Item1 - startDate).TotalMinutes, End = (int)(s.Item2 - startDate).TotalMinutes}).ToList();
            tree = new Node[wholeInterval.End * 2 + 1];
            //insert secondary intervals
            secondaryIntervals.ForEach(s => Search(wholeInterval, s, 1));
            //insert main interval
            var result = Search(wholeInterval, mainInvterval, 1);
            //calculate result
            var minutes = result.Sum(r => r.End - r.Start) + result.Count();
        }
        public IEnumerable<Interval> Search(Interval current, Interval searching, int index)
        {
            if (tree[index] == Node.Used || searching.End < searching.Start)
            {
                return new List<Interval>();
            }
            if (tree[index] == Node.Unvisited && current.Start == searching.Start && current.End == searching.End)
            {
                tree[index] = Node.Used;
                return new List<Interval> { current };
            }
            tree[index] = Node.Visited;
            return Search(new Interval { Start = current.Start, End = current.Start + (current.End - current.Start) / 2 },
                      new Interval { Start = searching.Start, End = Math.Min(searching.End, current.Start + (current.End - current.Start) / 2)  }, index * 2).Union(
                Search(new Interval { Start = current.Start + (current.End - current.Start) / 2 + 1 , End = current.End},
                  new Interval { Start = Math.Max(searching.Start, current.Start + (current.End - current.Start) / 2 + 1), End = searching.End }, index * 2 + 1));
        }
