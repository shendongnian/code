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
        try
        {
            if (!this.service.EditMonkey(voodooMonkey))
	        {
                //I'm thinking you need this line here in case the Redirect does the Thread.Abort() before the finally gets called. (Is that possible? Too lazy to test. :) Probably a race condition--I'd keep it for a guaruntee)
	            Session.IsEditActive = false;
                return RedirectToAction("Edit",voodooMonkey);
	        }
        }
        finally
        {
            //Ensure that we re-enable edits, even on errors.
	        Session.IsEditActive = false;
        }
        return RedirectToAction("Index");
    }
