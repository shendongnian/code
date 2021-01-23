    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
             rptHistoricoAnalises.DataSource = MyDataLayer.GetData();
             rptHistoricoAnalises.DataBind();
        }
    }
