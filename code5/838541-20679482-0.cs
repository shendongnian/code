    public string GetHtmlPage(string urlToFetch)
    {
        string page = "";
    
        try
        {
            ... code ...
    
            return page;
        } catch (Exception exc)
        {
            throw new HtmlPageRetrievalException(exc);
        }
    }
