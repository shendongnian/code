    protected void Button5_Click(object sender, EventArgs e)
    {
        if (StringIsNullOrEmpty(Label3.Text))
        {
            Label3.Text = TextBox1.Text;
        }
        if (StringIsNullOrEmpty(Label4.Text))
        {
            Label4.Text = TextBox1.Text;
        }
    }
