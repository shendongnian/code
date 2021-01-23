     protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TextBox txtValue = new TextBox();
            txtValue.Text = Request.Form[txtTotalAmt.UniqueID];
        }
    }
