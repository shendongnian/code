	db.Records
	.Where(i => i.Form.CompetitionID == cID)
	.GroupBy(i => i.Nickname)
	.Select(g => new { MaxCount = g.Count(), MaxDate = g.Max(i => i.DateAdded), Nickname = g.Key})
	.OrderByDescending(gx => gx.MaxCount)
	.ThenByDescending(gx => gx.MaxDate)
	.Select(gx => new TopUserModel()
	{
	     Nickname = gx.Nickname,
	     Position = gx.MaxCount
	}).Take(100).ToList();
