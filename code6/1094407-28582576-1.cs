	public void CreateCsvFile()
	{
		var filepath = @"F:\A2 Computing\C# Programming Project\ScheduleFile.csv";
		var ListGather = new PaceCalculator();
	
		var records =
			from record in ListGather.NameGain()
				.Zip(ListGather.PaceGain(),
					(a, b) => new { Name = a, Pace = b })
			group record.Pace by record.Name into grs
			select String.Format("{0},{1}", grs.Key, grs.Average());
			
		File.WriteAllLines(filepath, records);
	}
