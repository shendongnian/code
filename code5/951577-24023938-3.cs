        protected string Scroll;
        protected void Page_Load(object sender, EventArgs e)
        {
            Scroll = "false";
            Page.MaintainScrollPositionOnPostBack = true;
        }
        protected void GridView1_PageIndexChanged(Object sender, EventArgs e)
        {
            Scroll = "true";
        }
