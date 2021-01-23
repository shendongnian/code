    // Property to access the view state data
    protected List<string> Links
    {
        get { return ViewState['links']; }
        set { ViewState['links'] = value; }
    }
    ...
    protected void Page_Load(object sender, EventArgs e)
    {
        ...
        if (this.Links != null && this.Links.Count > 0)
        {
            // inside this method you create your link buttons and add them to the page
            // you actually have this code already
            RenderLinkButtons();
        }
    }
    ...
    // Not sure about what name you have here
    protected void InitialButtonHandlerName(object sender, EventArgs e)
    {
        List<string> linkList = ...; //your variable, guessing a type
        // this is exactly the method you use already to add links to the page
        // just one more action added to it - store info about these links into View State to use it on later post backs
        this.Links = linkList;
        RenderLinkButtons();    
    }
