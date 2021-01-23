	using (TestContext db = new TestContext())
	{
		if (!db.Items.Any())
		{
			foreach (int i in Enumerable.Range(0, 3500)) // Fill 3500 lines
			{
				byte[] dummyData = new byte[1 << 18];  // with 256 Kbyte
				new Random().NextBytes(dummyData);
				db.Items.Add(new TestItem() { Name = i.ToString(), BinaryData = dummyData });
			}
			await db.SaveChangesAsync();
		}
	}
	using (TestContext db = new TestContext())  // EF Warm Up
	{
		var warmItUp = db.Items.FirstOrDefault();
		warmItUp = await db.Items.FirstOrDefaultAsync();
	}
	Stopwatch watch = new Stopwatch();
	using (TestContext db = new TestContext())
	{
		watch.Start();
		var testRegular = db.Items.ToList();
		watch.Stop();
		Console.WriteLine("non async : " + watch.ElapsedMilliseconds);
    }
	using (TestContext db = new TestContext())
    {
		watch.Restart();
		var testAsync = await db.Items.ToListAsync();
		watch.Stop();
		Console.WriteLine("async : " + watch.ElapsedMilliseconds);
	}
    using (var connection = new SqlConnection(CS))
	{
		await connection.OpenAsync();
		using (var cmd = new SqlCommand("SELECT ID, Name, BinaryData FROM dbo.TestItems", connection))
		{
			watch.Restart();
			List<TestItem> itemsWithAdo = new List<TestItem>();
			var reader = await cmd.ExecuteReaderAsync(CommandBehavior.SequentialAccess);
			while (await reader.ReadAsync())
			{
				var item = new TestItem();
				item.ID = (int)reader[0];
				item.Name = (String)reader[1];
				item.BinaryData = (byte[])reader[2];
				itemsWithAdo.Add(item);
			}
			watch.Stop();
			Console.WriteLine("ExecuteReaderAsync SequentialAccess : " + watch.ElapsedMilliseconds);
		}
	}
	using (var connection = new SqlConnection(CS))
	{
		await connection.OpenAsync();
		using (var cmd = new SqlCommand("SELECT ID, Name, BinaryData FROM dbo.TestItems", connection))
		{
			watch.Restart();
			List<TestItem> itemsWithAdo = new List<TestItem>();
			var reader = await cmd.ExecuteReaderAsync(CommandBehavior.Default);
			while (await reader.ReadAsync())
			{
				var item = new TestItem();
				item.ID = (int)reader[0];
				item.Name = (String)reader[1];
				item.BinaryData = (byte[])reader[2];
				itemsWithAdo.Add(item);
			}
			watch.Stop();
			Console.WriteLine("ExecuteReaderAsync Default : " + watch.ElapsedMilliseconds);
		}
	}
	using (var connection = new SqlConnection(CS))
	{
		await connection.OpenAsync();
		using (var cmd = new SqlCommand("SELECT ID, Name, BinaryData FROM dbo.TestItems", connection))
		{
			watch.Restart();
			List<TestItem> itemsWithAdo = new List<TestItem>();
			var reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
			while (reader.Read())
			{
				var item = new TestItem();
				item.ID = (int)reader[0];
				item.Name = (String)reader[1];
				item.BinaryData = (byte[])reader[2];
				itemsWithAdo.Add(item);
			}
			watch.Stop();
			Console.WriteLine("ExecuteReader SequentialAccess : " + watch.ElapsedMilliseconds);
		}
	}
	using (var connection = new SqlConnection(CS))
	{
		await connection.OpenAsync();
		using (var cmd = new SqlCommand("SELECT ID, Name, BinaryData FROM dbo.TestItems", connection))
		{
			watch.Restart();
			List<TestItem> itemsWithAdo = new List<TestItem>();
			var reader = cmd.ExecuteReader(CommandBehavior.Default);
			while (reader.Read())
			{
				var item = new TestItem();
				item.ID = (int)reader[0];
				item.Name = (String)reader[1];
				item.BinaryData = (byte[])reader[2];
				itemsWithAdo.Add(item);
			}
			watch.Stop();
			Console.WriteLine("ExecuteReader Default : " + watch.ElapsedMilliseconds);
		}
	}
