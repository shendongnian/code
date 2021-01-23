    protected void Button1_Click(object sender, EventArgs e)
        {
            localhost.Service obj = new localhost.Service();
    
            TextBox1.Text = obj.Translate(TextBox1.Text);
        }
