    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
        }
    }
