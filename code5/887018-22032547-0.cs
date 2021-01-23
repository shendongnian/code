    protected void Page_Load(object sender, EventArgs e)
    {
      if(!isPostBack) //This condition allows a code to execute once when your page is load first time.
       {
        Label1.Text = "TextBox1.Text = " + TextBox1.Text + "<br />";
        Label1.Text += "TextBox1.Forecolor = " TextBox1.ForeColor.ToString();
       }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "Some more text";
        TextBox1.ForColor = System.Drawing.Color.Blue;
    }
