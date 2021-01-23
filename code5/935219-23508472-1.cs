    int? last = null;
    int count = 0;
    var counts = new List<Tuple<int, int>>();
    for (int i = 0; i < ip.Length; i++)
    {
        var cur = ip[i];
        if (last == null)
        {
            last = cur;
            count = 1;
            continue;
        }
        if (cur == last)
        {
            count++;
        }
        else
        {
            if (last != 0)
            {
                counts.Add(Tuple.Create(last.Value, count));
            }
            count = 1;
            last = cur;
        }
        if (i == ip.Length-1)
        {
            counts.Add(Tuple.Create(cur, count));
        }
    }
    var longestRun = counts.Max(x => x.Item2);
