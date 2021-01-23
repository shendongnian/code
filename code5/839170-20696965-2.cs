    private void button3_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(textBox1.Text))
        {
            if (listBox1.Items.Contains(textBox1.Text))
            {
                listBox1.Items.Remove(textBox1.Text);
            }
        }
    }
