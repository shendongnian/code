    private void textBox2_Leave(object sender, EventArgs e)
    {
        if (!button3.Focused)
        {
            button3.Visible = false;
        }
    }
    private void button3_Leave(object sender, EventArgs e)
    {
        if (!textBox2.Focused)
        {
            button3.Visible = false;
        }
    }
    private void textBox2_Enter(object sender, EventArgs e)
    {
        button3.Visible = true;
    }
    private void button3_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Button clicked");
    }
