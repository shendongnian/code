    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        Calendar1.Visible = false;
      }
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
      Calendar1.Visible = false;
    }
    protected void btnSelectDate_Click(object sender, EventArgs e)
    {
      Calendar1.Visible = true;
    }
