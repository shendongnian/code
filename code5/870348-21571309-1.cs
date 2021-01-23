    public ActionResult Index(int id = 0)
        {
            JObSummaryModelHelper jobDetails = new JObSummaryModelHelper();
           
            ViewBag.IsResults = false;
    
            if (id != 0)
            {
                ViewBag.IsResults = true;            
            }
            jobDetails .jdata = db.Jobs.Where(c => c.ID == id).Select(c => new JobSummaryModel() { ID = c.ID, Name = c.Name, City = c.City, PostalCode = c.PostalCode, JobDescription = c.PositionDescription }).ToList();
            return View(jobDetails );
        }
