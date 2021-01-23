    private void button1_Click(object sender, EventArgs e)
    {
        textBox2.TextChanged += new EventHandler(textbox1_TextChanged);
    }
    private void textbox1_TextChanged(object sender, EventArgs e)
    {
        MessageBox.Show("this");
    }
