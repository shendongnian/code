        private string BackToLastPage //THIS WILL NOW PERSIST POSTBACKS
        { 
            get { return hfPreviousUrl.Value; } 
            set { hfPreviousUrl.Value = value;}
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)//THIS PREVENTS THE VALUE FROM BEING RESET ON BUTTON CLICK
                BackToLastPage = (string)Session["CurrentUrl"];
            int BrugerId = Convert.ToInt32(Session["BrugerId"]);
            int TeamId = Convert.ToInt32(Request.QueryString["HoldId"]);
            //Resets sessionurl.
            Session["CurrentUrl"] = null;
            if (Session["brugerId"] != null)
            {
                Response.Write("brugerID was not null");
            }
            else
            {
                //REMOVED FOR TEST PURPOSES
                //Response.Redirect("Login.aspx");
            }
        }
        protected void BackToLastPageBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect(BackToLastPage);
        }
