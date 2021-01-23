	public static async Task TestMethod()
	{ 
		using (TestContext db = new TestContext())
		{
			if (!db.Items.Any())
			{
				foreach (int i in Enumerable.Range(0, 10)) // Fill 10 lines
				{
					byte[] dummyData = new byte[1 << 20];  // with 1 Mbyte
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
			watch.Restart();
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
	}
