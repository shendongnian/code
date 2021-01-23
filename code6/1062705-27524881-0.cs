    protected void Button1_Click(object sender, EventArgs e)
    {
            if (TextBox1.Text == "")
                Label1.Visible = true;
        
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
            if(TextBox1.Text != string.empty)
            {
                Label1.Visible = false;
            }
        
    }
