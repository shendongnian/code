    [HttpPost]
    public ActionResult SomeAction(ViewModel obj)
    {
     if(Request.Form["SubmitForm"] == "Preview")
     {
       // Preview Clicked
     }
     if(Request.Form["SubmitForm"] == "Save")
     {
       // Save Clicked
     }
    }
