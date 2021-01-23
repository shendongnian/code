    public MainWindow()
    {
        this.Links = this.GetLinks();
        InitializeComponent();
        this.DataContext = this;
    }
    private void GetLinks()
    {
       var links = new List<string>();
       HtmlDocument doc = new HtmlDocument();
       doc.Load(/*PutHereYourHtmlFile*/);
       foreach(HtmlNode link in doc.DocumentElement.SelectNodes("//a[@href"])
       {
          HtmlAttribute attribute = link["href"];
          if (attribute != null)
          {
             links.Add(att.Value);
          }
       }
       return links;
    }
