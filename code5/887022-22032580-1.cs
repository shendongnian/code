    bool IsClick=false;
    protected void Page_Load(object sender, EventArgs e)
    {    
        Label1.Text = "TextBox1.Text = " + TextBox1.Text + "<br />";
        Label1.Text += "TextBox1.Forecolor = " TextBox1.ForeColor.ToString();
        if(IsClick)
        {
        TextBox1.Text = "Some more text";
        TextBox1.ForeColor = System.Drawing.Color.Blue;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
      IsClick=true;
    }
