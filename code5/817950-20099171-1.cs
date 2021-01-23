        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                if (Request["__EVENTTARGET"] == "row")
                {
                    string idClicked = Request["__EVENTARGUMENT"];
                    Response.Redirect(mydetailpage.aspx?id=" + idClicked);
                }
            }
        }
