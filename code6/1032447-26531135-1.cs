    [HttpPost]
    public ActionResult SomeAction(FormCollection form,ViewModel obj)
    {
       if(form["SubmitForm"] == "Preview")
       {
         // Preview Clicked
       }
       if(form["SubmitForm"] == "Save")
       {
         // Save Clicked
       }
    }
