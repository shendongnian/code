	[TestMethod]
	public void MakeTwoCallsDifferentIdsFails()
	{
		int idOne = 1;
		int idTwo = 2;
		DataTable dt = new DataTable();
		dt.Columns.Add("Id");
		dt.Rows.Add(idOne);
		dt.Rows.Add(idTwo);
		IProcessor mock = Mock.Create<IProcessor>();
		Mock.Arrange(() => mock.Process(Arg.Matches<MyArgs>(d => d.Id == idOne))).OccursOnce();
		Mock.Arrange(() => mock.Process(Arg.Matches<MyArgs>(d => d.Id == idTwo))).OccursOnce();
		Runner runner = new Runner(mock);
		runner.Process(dt);
		Mock.Assert(mock);
	}
