    protected void Page_Load(object sender, EventArgs e)
    {
      if(!Page.IsPostBack)
      {
        if (Session["New"] != null)
           Label4.Text = Session["New"].ToString();
      }
    }
