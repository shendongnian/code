	public int TestA()
	{
		var gc0 = GC.CollectionCount(0);
		using (var u = new UnitOfWork())
		{
			var s = Stopwatch.StartNew();
			var x = 0;
			var repo = u.Repository<MyEntity>();
			var code = "ABCD".First().ToString();
			while (x < 10000)
			{
				var testCase = repo.Single(w => w.Code == code && w.CodeOrder == 0).Name;
				x++;
			}
			s.Stop();
		}
		return GC.CollectionCount(0) - gc0;
	}
