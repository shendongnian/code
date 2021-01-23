    [HttpPost]
    public ActionResult GetSessionVariable()
    {
        const string sessionVariableName = "MySessionVariable";
    
        var sessionVariable = Session[sessionVariableName] as string;
    
        if (sessionVariable == null)
        {
            Session[sessionVariableName] = "No";
            sessionVariable = "No";
        }
    
        return Content(sessionVariable);
    }
