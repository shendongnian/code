    protected void Page_Load(object sender, EventArgs e) 
    { 
        if (this.Page.IsPostBack)
           return;
    
        var path = Server.MapPath(@"~/content.txt");
        string content = System.IO.File.ReadAllText(path);
        txtHomepageContent.Text = content;
    }
