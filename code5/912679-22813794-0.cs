	[HttpPost]
	public ActionResult Press(string nextStep)
	{
		// not sure what this functionality does...
		//SelectedSequenceID ++;         
		//return RedirectToAction("Game", "Game");
		
		switch (step)
		{
			case "Intro":
				// call method to run intro method or redirect to intro action
				break;
			default:
				// return to start
				break;
		}
	}
