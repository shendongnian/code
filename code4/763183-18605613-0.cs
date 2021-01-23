      public ActionResult Create()
            {
    
                return View(createViewModel(new Job()));
            }
    
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(Job job, string action)
            {
    
                if (ModelState.IsValid)
                {
                    db.Jobs.Add(job);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }            
    
                return View(createViewModel(job));
            }
    
            private JobViewModel createViewModel(Job job)
            {
                var fileManagers = from x in db.UserProfiles
                                   select x;
    
                var estimators = from x in db.UserProfiles
                                 select x;
    
                var projectManagers = from x in db.UserProfiles
                                      select x;
    
                var jobStatuses = from x in db.JobStatuses
                                  select x;
    
                JobViewModel viewModel = new JobViewModel
                {
                    Job = job,
                    FileManagers = fileManagers.Select(x => new SelectListItem
                    {
                        Value = x.UserName,
                        Text = x.FirstName + " " + x.LastName
                    }).ToList(),
                    Estimators = estimators.Select(x => new SelectListItem
                    {
                        Value = x.UserName,
                        Text = x.FirstName + " " + x.LastName
                    }).ToList(),
                    ProjectManagers = projectManagers.Select(x => new SelectListItem
                    {
                        Value = x.UserName,
                        Text = x.FirstName + " " + x.LastName
                    }).ToList()
                };
    
                return viewModel;
            }
