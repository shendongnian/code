    public void TextBox1_TextChanged(object sender, EventArgs ea)
    {
        if (textBox1.Modified) textBox2.Clear(); 
    }
    public void TextBox2_TextChanged(object sender, EventArgs ea)
    {
        if (textBox2.Modified) textBox1.Clear(); 
    }
