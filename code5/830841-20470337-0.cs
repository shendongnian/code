    var serieses = input.Aggregate(
        new List<Tuple<int, int>>(),
        (l, i) =>
            {
                var last = l.LastOrDefault();
                if (last == null ||
                    last.Item1 + last.Item2 != i)
                {
                    l.Add(new Tuple<int, int>(i, 1));
                }
                else if (last.Item1 + last.Item2 == i)
                {
                    l.RemoveAt(l.Count - 1);
                    l.Add(new Tuple<int, int>(last.Item1, last.Item2 + 1));
                }
                return l;
            },
        l => l);
