    /// <summary>
    /// Retrieves the control that caused the postback.
    /// </summary>
    /// <param name="page"></param>
    /// <returns></returns>
    private Control GetControlThatCausedPostBack(Page page)
    {
        //initialize a control and set it to null
        Control ctrl = null;
    
        //get the event target name and find the control
        string ctrlName = page.Request.Params.Get("__EVENTTARGET");
        if (!String.IsNullOrEmpty(ctrlName))
            ctrl = page.FindControl(ctrlName);
    
        //return the control to the calling method
        return ctrl;
    }
