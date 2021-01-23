	private class TestObject1
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
	IDisplayColumn objectColumn = new DisplayColumn<TestObject1> { Title = "Column 1", Selector = (x) => x.Name };
	
	var columnSets = new List<IColumnSet>
	{
		new ColumnSet<TestObject1>
		{
			Columns = new List<IDisplayColumn>
			{
				new DisplayColumn<TestObject1> { Title = "Column 1", Order = 3, Selector = x => x.Id },
				new DisplayColumn<TestObject1> { Title = "Column 2", Order = 2, Selector = x => x.Name },
				new DisplayColumn<TestObject1> { Title = "Column 3", Order = 1, Selector = x => x.Id.ToString(CultureInfo.InvariantCulture) + x.Name.ValueOrEmpty() },
			}
		}
	};
