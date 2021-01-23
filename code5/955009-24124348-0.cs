	public ActionResult Action(int id)
    {
        var model = new MyViewModel();
        using (var db = new PipelineDB())
        {
            model.salesStages = db.Entries.ToList().Select(x => new SelectListItem
                {
                    Value = x.currentSalesStage.ToString(),
                    Text = x.Name
                });
			
			model = new pipeline();
        }
        return View(model);
    }
