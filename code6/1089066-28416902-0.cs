    var model = (new List<string>())
		.Concat(db.UserProfiles
                .Where(u => (u.FirstName + " " + u.LastName).Contains(term))
                .Select(u => (u.FirstName + " " + u.LastName))
                .Distinct())
		.Concat(db.UserProfiles
                .Where(u => u.Department.Contains(term))
                .Select(u => u.Department)
                .Distinct())
		.Concat(db.UserProfiles
                .Where(u => u.JobTitle.Contains(term))
                .Select(u => u.JobTitle)
                .Distinct())
		.Concat(db.UserProfiles
                .Where(u => u.PhoneNumber.Contains(term))
                .Select(u => u.PhoneNumber)
                .Distinct())
		.Concat(db.UserProfiles
                .Where(u => u.Extension.Contains(term))
                .Select(u => u.Extension)
                .Distinct())
		.Concat(db.UserProfiles
                .Where(u => u.Location.Contains(term))
                .Select(u => u.Location)
                .Distinct())
        .OrderBy( s => s )//must have an orderby in order to use Take
        .Take(10)
		.ToList();
    return Json(model, JsonRequestBehavior.AllowGet);
