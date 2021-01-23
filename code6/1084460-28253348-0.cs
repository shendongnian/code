    protected void Page_Init (object sender, EventArgs e)
    {
        if(!IsQueryStringValid(Request.QueryString))
        {
            Response.Write("Please don't change anything in the URL");
            Response.End();
            // OR
            // Response.Redirect("~/QueryStringModifiedError.aspx");
        }
    }
