    protected void Page_Load(object sender, EventArgs e)
    {
        var cph = Page.Master.FindControl("Content") as ContentPlaceHolder;
        if (contentPlaceHolder != null)
        {
            string textualContent = ((LiteralControl) cph.Controls[0]).Text;
            if (string.IsNullOrEmpty(textualContent))
            {
                // ...
            }
        }
    }
