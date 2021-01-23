	public long TestA()
	{
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
			return s.ElapsedMilliseconds;
		}
	}
