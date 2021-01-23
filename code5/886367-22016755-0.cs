    protected override void Render(HtmlTextWriter writer)
    {
        if (update) // globally declared update boolean to check if the page is being updated 
        {
            HtmlGenericControl sAguarde = (HtmlGenericControl) UpdateProgress1.FindControl("sAguarde");
            Aguarde.InnerHTML = "Hi";
        }
        base.Render(writer);
    }
