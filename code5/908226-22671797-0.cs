    protected void textbox_TextChanged(object sender, EventArgs e)
    {
        
        var total = int.Parse(textBox1.Text) + int.Parse(textBox2.Text);
        Label1.Text = total.ToString();
    }
