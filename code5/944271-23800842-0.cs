    public static System.Web.UI.HtmlControls.HtmlForm GetHtmlForm()
    {
        var context = HttpContext.Current;
        if (context != null)
        {
            Page currentPage = context.CurrentHandler as Page;
            if (currentPage != null)
                return currentPage.Form;
        }
        return null;
    }
