One easy way to do it is just to add the bool mode to the action method:
    public ActionResult ReadFromExcel(bool Mode)
    {
        //Use the selected Mode...
        var file = Request.Files[0].
        // file contains the correct value.
        // Unable to retrieve mode value though.
    }
