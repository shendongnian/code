    [HttpPost]
    public ActionResult Generate(WorkItemScheduleViewModel viewModel)
    {
        WorkItem workItem = viewModel.WorkItem;
        db.WorkItems.Attach(workItem);
        db.Entry(workItem).State = EntityState.Added;
        db.SaveChanges();
    
        return RedirectToAction("Index", "WorkItem");
    }
