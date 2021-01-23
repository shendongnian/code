    public static MvcHtmlString CustomActionLink( this HtmlHelper htmlHelper, SqlConnection con)
    {
        //do your retrival logic here
        // create a linktext string which displays the inner text of the anchor
        // create an actionname string which calls the controller
        StringBuilder result = new StringBuilder();
        result.Append(linktext);
        result.Append(actionname);
        return new MvcHtmlString(result);
    }
