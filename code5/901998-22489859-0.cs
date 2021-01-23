    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            MyLiteral.Text=AppNamespace.App.AppDoSomething();
        }
    }
