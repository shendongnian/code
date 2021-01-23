            var index2 = list2.ToLookup(t => Tuple.Create(t.Item1, t.Item3));
            //var index2 = list2.Select(l => Tuple.Create(l.Item1, l.Item3)).ToList();
            //index2.Sort();
            var results = from l in list1
                          where !index2.Contains(new Tuple<int,int>(l.Item1, l.Item3))
                          select l;
