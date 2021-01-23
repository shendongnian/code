    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        // Only store on first visit to the page
        ViewState["pageLoadTime"] = DateTime.Now;
      }
    }
    protected void checkoutbutton_click(object sender, EventArgs e)
    {
      TimeSpan diff = DateTime.Now - (DateTime)ViewState["pageLoadTime"];
    }
