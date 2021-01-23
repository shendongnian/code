	// test data
	var data = new List<Int32> { 1, 20, 30, 40, 50, 70 };
	// create a list of anonymous objects
	var result = data.Select (d => new 
	{
		Count = d,
		State = String.Format("Item {0}", d),
		SavingBalance = d * 10
	});
	// create the output text buffer
	var buffer = new StringBuilder();
	// add header line
	buffer.AppendLine("#key,name,sum");
	// add each result line
	result.ToList().ForEach(item => buffer.AppendLine(String.Format("{0},{1},{2}", item.Count, item.State, item.SavingBalance)));
	// write to file
	File.WriteAllText("d:\\temp\\file.csv", buffer.ToString());
