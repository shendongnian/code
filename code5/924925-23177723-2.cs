    private void textBox_TextChanged(object sender, EventArgs e)
    {
        TextBox tb = (TextBox)sender;
        if (tb.Equals(textBox1))
        {
            if (textBox2.Text != tb.Text)
            {
                textBox2.Text = tb.Text;
                textBox2.SelectionStart = tb.SelectionStart;
                textBox2.Focus();
            }
        }
        else
        {
            if (textBox1.Text != tb.Text)
            {
                textBox1.Text = tb.Text;
                textBox1.SelectionStart = tb.SelectionStart;
                textBox1.Focus();
            }
        }
    }
