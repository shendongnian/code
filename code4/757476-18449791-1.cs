    protected void Page_Load(object sender, EventArgs e)
      {
        if (IsPostBack)
        {
          Page.ClientScript.RegisterStartupScript(this.GetType(), null, "getConfirm();", true);
        }
      }
