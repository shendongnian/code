 	public void GetSqlCommand()
	{
		const string sc2 = @"Server=SQLServerName;Database=DatabaseName;Trusted_Connection=True;";
		using (var dc = new DataContext(sc2))
		{
			var query = dc.GetTable<Users>()
				.Join(dc.GetTable<Phone>(),
					x => x.UserId,
					y => y.LastUserId,
					(x, y) => new { User = x, Phone = y }).Select(x => x);
				DbCommand command = dc.GetCommand(query);
				Assert.IsNotNull(command.CommandText);
		}
	}
