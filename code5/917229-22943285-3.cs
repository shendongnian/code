	var schedules = new List<Schedule> {
		new Schedule { ID = 1, Start = DateTime.Parse("09:00 AM"), End = DateTime.Parse("09:30 AM") },
		new Schedule { ID = 2, Start = DateTime.Parse("09:30 AM"), End = DateTime.Parse("10:00 AM") },
		new Schedule { ID = 3, Start = DateTime.Parse("10:00 AM"), End = DateTime.Parse("10:30 AM") },
		new Schedule { ID = 4, Start = DateTime.Parse("10:30 AM"), End = DateTime.Parse("11:00 AM") },
	};
	
	foreach (var s in schedules) {
		s.Minutes = (int)(s.End - s.Start).TotalMinutes;
	}
	
	Console.WriteLine("60 Minute Blocks");
	Console.WriteLine("----------------");
	var blocks = FindBlocks(schedules, 60);
	var blockId = 1;
	foreach (var block in blocks) {
		var output = "Block" + blockId + 
			": Schedules(" + string.Join(",", block.Schedules.Select (s => s.ID)) + "): " +
			block.Start.ToString("h:mmtt") + " - " + block.End.ToString("h:mmtt");
		Console.WriteLine(output);
		blockId++;
	}
	
	Console.WriteLine();
	Console.WriteLine("120 Minute Blocks");
	Console.WriteLine("----------------");
	blocks = FindBlocks(schedules, 120);
	blockId = 1;
	foreach (var block in blocks) {
		var output = "Block" + blockId + 
			": Schedules(" + string.Join(",", block.Schedules.Select (s => s.ID)) + "): " +
			block.Start.ToString("h:mmtt") + " - " + block.End.ToString("h:mmtt");
		Console.WriteLine(output);
		blockId++;
	}
