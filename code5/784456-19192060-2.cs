    //Will be used to load the control
    var loader = new Page();
    var ctl = (UserComments)loader.LoadControl("~/Controls/UserComments.ascx");
    //Set the comments property of the control
    ctl.Comments = _callAdapter.GetCallComments(callId);
    ctl.BindComments();
    
    //Create streams the control will be rendered to
    TextWriter txtWriter = new StringWriter();
    HtmlTextWriter writer = new HtmlTextWriter(txtWriter);
    //Render the control and write it to the stream
    ctl.RenderControl(writer);
    //Return the HTML
    return txtWriter.ToString();
