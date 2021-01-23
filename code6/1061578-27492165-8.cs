    public void Page_Load(object o, EventArgs e)
    {
        if (!IsPostBack)
        {
             Session["firstItem"] = 1;
             Session["lastItem"] = 5;
        }
    }
