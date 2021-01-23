    protected void Page_Load(object sender, EventArgs e)
        {
                        List<StateList> states = ops.getStates();
                        ddlStateLegalRes.DataTextField = "StateRegionName";
                        ddlStateLegalRes.DataValueField = "StateRegionCode";
                        ddlStateLegalRes.DataSource = states;
                        ddlStateLegalRes.DataBind();
    
                    if (!Page.IsPostBack)
                    {
    
    
                        GetAllInfo();
                    }
        }
