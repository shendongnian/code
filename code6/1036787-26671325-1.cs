    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtInvoiceID.Text = Request.QueryString["Id"];
        }
    }
     
    protected void btnRedirect_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx?Id=" + txtInvoiceID.Text.Trim());
    }
