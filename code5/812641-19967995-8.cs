	[Route("new-actions/action-tab-details/{actionTabGuid}")]
	[Route("continues-actions/action-tab-details/{actionTabGuid}")]
	[Route("finished-actions/action-tab-details/{actionTabGuid}")]
	public ActionResult ActionTabDetails(Guid actionTabGuid)
	{
		ActionTab model = actionTabRepo.Get(actionTabGuid, "ActionGroup");
		if (model.Status == ActionStatus.New)
		{
			  //Parameter with I want to pass to the DynamicNodeProvider or select current node
		}
		//another conditions
		return View("ActionTab/ActionTabDetails", model);
	}
