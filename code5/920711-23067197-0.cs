    public void grabLink()
    {
        HtmlElementCollection links = webBrowser3.Document.Links ;
        using (TextWriter tw = new StreamWriter("link.tnx"))
        {
            foreach (HtmlElement  link in links)
            {
                if (link.InnerHtml.Contains("Sign Up"))
                {
                    tw.WriteLine(link.OuterHtml);
                }
            }
        }
    }
