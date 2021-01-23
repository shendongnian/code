    protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
                Session["X"] = x;
            int valueFromSession = Convert.ToInt32(Session["X"]);
            Label1.Text = valueFromSession.ToString();
        }
    
        protected void Button1_Click(object sender, EventArgs e)
        {
           int valueFromSession = Convert.ToInt32(Session["X"]);
             valueFromSession++;
           Session["X"] = valueFromSession;
            Label1.Text = valueFromSession.ToString();
        }
