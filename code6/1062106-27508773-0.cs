    //Parent Control Visible
    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        richTextBox1_KeyPress(sender, e);
    }
    //Child Control Hidden
    private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        richTextBox1.Text += e.KeyChar.ToString();
    }
