    protected void Page_Load(object sender, EventArgs e)
    {
            if (!Page.IsPostBack) 
            {
                string activeView = Request.QueryString["activeView"]
                if(!string.IsNullOrEmpty(activeView) && activeView == "View2")
                    MultiView1.SetActiveView(View2);
                else 
                    MultiView1.SetActiveView(View1);
            }
    }
