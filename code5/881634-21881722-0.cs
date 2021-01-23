    protected void Page_Load(object sender, EventArgs e)
    {
      if(!Page.IsPostBack)
      {
        Label4.Text = Session["New"].ToString();
      }
    }
