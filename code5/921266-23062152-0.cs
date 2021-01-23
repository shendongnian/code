     protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["a"]==null)
            {
                Response.Write("Session is empty");
            }
            else
            {
                Response.Write("Session is not empty");
                Response.Write(Session["a"].ToString());
            }
            if (!Page.IsPostBack)
            {
                Session["a"] = "Jalpesh";
            }
        }
