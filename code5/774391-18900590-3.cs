   	List<Data> data = new List<Data>
	{
            new Data { ID = 0, Value = 3.2m },
            new Data { ID = 1, Value = 6.9m },
            new Data { ID = 2, Value = 9.4m },
            new Data { ID = 3, Value = 2.1m },
            new Data { ID = 4, Value = 8.4m },
            new Data { ID = 5, Value = 1.1m },
            new Data { ID = 0, Value = 6.8m }
	};
	List<Data> dupe = (
	    from d in data
		group d by d.ID into g
		where g.Count() > 1
		select new Data { ID = g.Key, Value = g.Select(v => v.Value).Sum() }).ToList();
	data.RemoveAll(d => dupe.Select(v => v.ID).Contains(d.ID));
	data.AddRange(dupe);
