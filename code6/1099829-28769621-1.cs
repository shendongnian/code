	[HttpGet]
	[Route("/thing/{Year}/{Month}"]
	public ActionResult Thing(WhateverModel model)
	{
		// use model
		return View();
	}
