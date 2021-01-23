    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            foreach (ListItem li in this.chkList.Items)
            {
                li.Attributes.Add("onclick", "CheckItem(this, document.getElementById('" + txtCombo.ClientID + "'), document.getElementById('" + hidVal.ClientID + "'))");
            }
        }
    }
