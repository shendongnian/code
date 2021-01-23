    protected void Page_Load(object sender, EventArgs e)
      {
        if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
        {
            if (!IsPostBack)
            {
            }
        }
        else
        {
            Response.Redirect("Default.aspx", false);
        }
    }
