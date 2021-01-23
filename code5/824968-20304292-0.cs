    protected void Page_Load(object sender, EventArgs e)
    {
        If(!Page.IsPostback)
        {
            TextBox1.Text = DateTime.Today.ToShortDateString();
            TextBox2.Text = DateTime.Today.ToShortDateString();
        }
    
    }
    
