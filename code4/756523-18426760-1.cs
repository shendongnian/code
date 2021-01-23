    [HttpPost] 
    public ActionResult SubmitAction(FormCollection frm)
    {    
        string id = frm.Get("id");
        string value2 = frm.Get("name2");
        string value3 = frm.Get("name3");
        // also for other inputs of the form which have name attribute...
    }
