    protected void Page_Load(object sender, EventArgs e)
    {
        ViewState["vsValue"]=value;
        if (IsPostBack==false)
        {
            Label1.Text = value.ToString();
        }
    }
