    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            TextBox1.Text="Some random text";
        }
    }
    
    protected void ResetBtn_Click(object sender, EventArgs e)
    {
        TextBox1.Text="";
    }
