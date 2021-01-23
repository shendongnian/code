    public ActionResult OpenTicket(string serialNumber, string version)
    {
       if (!customerSubscription.IsExpired)           
       {
           // use the Redirect method from base controller
           return Redirect("https://devdept.zendesk.com/tickets/new?ticket[fields[111111]]=" + serialNumber + "&ticket[fields[222222]]=" + version);
       }
       else
       {
           // display an error page with upsell options
           ModelState.AddModelError("ErrorKey", "Custom error message");
           // it will return OpenTicket view, otr pass a name you want to return
           return View(); 
           // if you redirect here, you will lose the ModelState.
       }   
    }
