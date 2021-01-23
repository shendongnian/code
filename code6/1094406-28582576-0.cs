	public void CreateCsvFile()
	{
		var filepath = @"F:\A2 Computing\C# Programming Project\ScheduleFile.csv";
		var ListGather = new PaceCalculator();
	
		var records =
			ListGather.NameGain()
				.Zip(ListGather.PaceGain(),
					(a, b) => String.Format("{0},{1}", a, b));
					
		File.WriteAllLines(filepath, records);
	}
