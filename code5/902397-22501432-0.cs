	using (var timesheetDb = new TimeSheetContext())
	{
		var comboItems = timesheetDb.TimeSheets.Select(row => row.Column1 + " (" + row.Description + ")").Distinct().ToList();
		foreach (var item in comboItems)
		{
			TestCombo.Items.Add(item);
		}
	}
