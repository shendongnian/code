    ViewBag.CodeSort = String.IsNullOrEmpty(sortOrder) ? "code_desc" : "";
    var sortedOut = new MkistatVsUserLogin { mkistats = dsedb.mkistats.AsQueryable() };     //Error in this line
	switch (sortOrder)
	{
		case "code_desc":
			sortedOut.mkistats = sortedOut.mkistats.OrderByDescending(s => s.MKISTAT_CODE);   //error in this line
			break;
		default:
			sortedOut.mkistats = sortedOut.mkistats.OrderBy(s => s.MKISTAT_CODE);    //error in this line
			break;
	}
	return View(sortedOut.mkistats.ToList());   //error in this line
