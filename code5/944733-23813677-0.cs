    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        if (textBox1.Text == "")
        {
            textBox2.Enabled = false;
            textBox2.Visible = false;
            label1.Visible = false;
        }
        else
        {
            textBox2.Enabled = true;
            textBox2.Visible = true;
            label1.Visible = true;
        }
    }
