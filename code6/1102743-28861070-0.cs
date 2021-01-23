    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            checkbox1.Checked = true;
        }
    }
