    public ActionResult DeleteFix(long vulnId, int currentFixId, string currentFixName) 
    {
        if (ModelState.IsValid)
		{
			DataModel.Vulnerability.Fix model = new DataModel.Vulnerability.Fix();
			manager.openConnection();
			try
			{
				model.Id = currentFixId;
				model.FixName = currentFixName;
			}
			finally
			{
				manager.closeConnection();
			}
			
			return Redirect(viewModel.BackUrl);
		}
		
		// Invalid viewstate, re-render the view
        return View(model);
    }
