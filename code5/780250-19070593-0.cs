    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == Keys.Enter)
        {
            Label1.Text = TextBox1.Text;
        }
    }
