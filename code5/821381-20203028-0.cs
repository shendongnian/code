        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.ViewStateMode = ViewStateMode.Disabled;//now a postback will lose data
            if (!IsPostBack)
            {
                GridView1.DataSource = new List<string> { "a", "b" };
                GridView1.DataBind();
            }
        }
