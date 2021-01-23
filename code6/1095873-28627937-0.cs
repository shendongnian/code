	void Main()
	{
		var ops  = new List<Ops>
		{ 
			new Ops
			{
				//OperandType = typeof(string), 
				OpType=OpType.Equals, 
				OperandName = "Name", 
				ValueToCompare = "MM"
			},
			new Ops
			{
				//OperandType = typeof(int), 
				OpType=OpType.Equals, 
				OperandName = "ID", 
				ValueToCompare = 1
			},
		};
		var testClasses = new List<TestClass>
		{
			new TestClass { ID =1, Name = "MM", Date = new DateTime(2014,12,1)},
			new TestClass { ID =2, Name = "BB", Date = new DateTime(2014,12,2)}
		};
		
		var funct = ExpressionBuilder.BuildExpressions<TestClass>(ops);
		foreach(var item in testClasses.Where(funct))
		{
			Console.WriteLine("ID " +item.ID);
			Console.WriteLine("Name " +item.Name);
			Console.WriteLine("Date" + item.Date);
		}
	}
