    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
            Session["cnt"] = 0;
        else
            DoIncrement();
    }
    protected void DoIncrement()
    {
        if(Session["cnt"] != null)
        {
            int _counter = (int)Session["cnt"];
            _counter++;
            Session["cnt"] = _counter;
            lblInfo.Text = _counter.ToString();    
        }  
    }
