   	List<Data> data = new List<Data>
	{
		new Data { ID = 0, Value = "A" },
		new Data { ID = 1, Value = "B" },
		new Data { ID = 2, Value = "C" },
		new Data { ID = 3, Value = "D" },
		new Data { ID = 4, Value = "E" },
		new Data { ID = 5, Value = "F" },
		new Data { ID = 0, Value = "G" }
	};
	List<Data> dupe = (
	    from d in data
		group d by d.ID into g
		where g.Count() > 1
		select new Data { ID = g.Key, Value = string.Join("", g.Select(v => v.Value).ToArray()) }).ToList();
	data.RemoveAll(d => dupe.Select(v => v.ID).Contains(d.ID));
	data.AddRange(dupe);
