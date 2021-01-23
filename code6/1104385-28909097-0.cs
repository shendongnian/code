    [HttpPost]
    [ValidateAntiForgeryToken]
    [SessionStateActionFilter]
    public ActionResult Edit(MonkeyJar voodooMonkey)
    {
	    //Prevent double-submit
    	if (Session.IsEditActive)
	    {
		    //TODO: determine if you want to show an error, or just ignore the request
	    }
	    Session.IsEditActive = true;
        if (!this.service.EditMonkey(voodooMonkey))
	    {
	        Session.IsEditActive = false;
            return RedirectToAction("Edit",voodooMonkey);
	    }
	    Session.IsEditActive = false;
        return RedirectToAction("Index");
    }
