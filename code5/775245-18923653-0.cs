    public void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Session["MyArrayList"] = null;
        }
    }
