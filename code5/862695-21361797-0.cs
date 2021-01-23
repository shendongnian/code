    protected void Page_Load(object sender, EventArgs e)
    {
        this.LinkButton1.Click += LinkButton1_Click;
    }
    private void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://www.google.com");
    }
