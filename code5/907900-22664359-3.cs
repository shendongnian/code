    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cblMultiple.Items.Add(new ListItem("All", "0"));
            for (int i = 1; i < 11; i++)
            {
                cblMultiple.Items.Add(new ListItem("All" + i, i.ToString()));
            }    
        }
    }
