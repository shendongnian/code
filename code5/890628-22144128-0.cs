    `private void textBox1_TextChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(textBox1.Text))
            button1.Enabled = false;
        else
                button1.Enabled = true;
    }`
