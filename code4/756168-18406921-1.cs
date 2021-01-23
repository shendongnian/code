    protected void Page_Load(object sender, EventArgs e)
    {
       if (!Page.IsPostBack)
       {
         //bind your datasource here (something like below)
         userDropDown.DataSource = GetCustomers();
         userDropDown.DataBind();
       }
    }
