    protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    // Checking this session on the page, on the page load event.
                    if (Session["user"] != null)
                    {
                        Response.Redirect("Home1.aspx");
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
