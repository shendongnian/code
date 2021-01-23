    public string OwnHtmlWithLineBreaks
    {
        get
        {
            return OwnHtml.Replace("<br />", System.Environment.NewLine);
        }
    }
