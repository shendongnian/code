    private class Content
    {
        public string Heading { get; set; };
        public string Paragraph { get; set; };
    }
    private List<Content> _content = new List<Content>();
    private void CreateContent()
    {
        _content.Add(new Content {Heading = "Heading 1", Paragraph = "Content"});
        _content.Add(new Content {Heading = "Heading 2", Paragraph = "More Content"});
        _content.Add(new Content {Heading = "Heading 3", Paragraph = "Even More Content"});
       literal1.Text = "";
       foreach (Content c in _content)
       {
           literal1.Text = string.Format("{0}<h1>{1}</h1><p>{2}</p>{3}", literal1.Text, HttpServerUtility.HtmlEncode(c.Heading), HttpServerUtility.HtmlEncode(c.Paragraph), Environment.Newline);
       }
    }
