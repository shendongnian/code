    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            myList = new List<Foo>();
            Session["myList"] = myList;
        }
        else
        {
            myList = Session["myList"] as List<Foo>;
        }
    }
