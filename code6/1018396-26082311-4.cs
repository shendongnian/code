    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            cblPayment1.DataSource = .... ;
            cblPayment1.DataBind();
        }
    } 
