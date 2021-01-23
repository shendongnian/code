    public string metaRedirect { get; set; }
    protected void Page_Load(object sender, EventArgs e) 
    {
    metaRedirect="Hello World.";
    Page.DataBind();
    }
