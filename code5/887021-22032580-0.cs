    protected void Page_Load(object sender, EventArgs e)
    {
      if(!IsPostBack)
        {
        Label1.Text = "TextBox1.Text = " + TextBox1.Text + "<br />";
        Label1.Text += "TextBox1.Forecolor = " TextBox1.ForeColor.ToString();
        }
    
    }
