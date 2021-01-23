	var tasks = new []
	{
		Task.Factory.StartNew(() => File.ReadAllText(@"file1.txt")),
		Task.Factory.StartNew(() => File.ReadAllText(@"file2.txt")),
		Task.Factory.StartNew(() => File.ReadAllText(@"file3.txt")),
	};
	
	Task.Factory.ContinueWhenAll(tasks, ts =>
	{
		var output = @"writefile.txt";
		File.WriteAllText(output, ts[0].Result);
		File.AppendAllText(output, ts[1].Result);
		File.AppendAllText(output, ts[2].Result);
		Console.WriteLine("Done.");
	});
