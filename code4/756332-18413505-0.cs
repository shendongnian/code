    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            // Put logic here to bind
            DropDownList2.DataSource = modelsList;  
            DropDownList2.DataBind();
        }
    }
