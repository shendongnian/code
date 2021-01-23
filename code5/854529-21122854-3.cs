        private string BackToLastPage { get { return (Session["CurrentUrl"] == null) ? "" : Session["CurrentUrl"].ToString(); } }
        protected void Page_Load(object sender, EventArgs e)
        {
            int BrugerId = Convert.ToInt32(Session["BrugerId"]);
            int TeamId = Convert.ToInt32(Request.QueryString["HoldId"]);
            if (Session["brugerId"] != null)
            {
                //CUT CODE OUT DONT HAVE YOUR DEFINITIONS
                Response.Write("brugerid was not null");
            }
        }
        protected void BackToLastPageBtn_Click(object sender, EventArgs e)
        {
            //YOU SHOULD SET THE CURRENT URL TO NULL HERE.
            Response.Redirect(BackToLastPage);
        }
