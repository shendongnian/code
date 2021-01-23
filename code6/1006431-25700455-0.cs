    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox1.Text = "OriginalContent "; // as example
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        String text = TextBox1.Text + TextBox2.Text;
    }
