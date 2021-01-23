    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack) // Don't forget this
        {
            grdLoan.DataSource = ...;
            grdLoan.DataBind();
        }
    }
