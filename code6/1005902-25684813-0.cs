    protected void Page_Load(Object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
             DataTable dt1 = BeeStatus.GetAllBeeStatus();
             radio1.DataSource = dt1;
             radio1.DataTextField = "beeStatus";
             radio1.DataValueField = "beestatusID";
             radio1.DataBind();
        }
    }
