    var users = db.UserProfiles
    .ToArray()
    .Select(x => new SelectListItem
    {
    	Value = x.UserName,
    	Text = x.FirstName + " " + x.LastName
    });
    
    var jobStatuses = from x in db.JobStatuses
    				  select x;
    
    JobViewModel viewModel = new JobViewModel
    {
    	Job = job,
    	FileManagers = users.ToList(),
    	Estimators = users.ToList(),
    	ProjectManagers = users.ToList()
    };
