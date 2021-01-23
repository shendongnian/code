	var start = new DateTime(
		DateTime.Today.Year,
		1 + 6 * (DateTime.Today.Month / 7),
		1);
	var end = new DateTime(
		DateTime.Today.Year + DateTime.Today.Month / 7,
		7 - 6 * (DateTime.Today.Month / 7),
		1).AddDays(-1.0);
