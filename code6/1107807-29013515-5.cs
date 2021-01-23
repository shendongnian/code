    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            myList = new List<Foo>();
            ViewState["myList"] = myList;
        }
        else
        {
            myList = ViewState["myList"] as List<Foo>;
        }
    }
