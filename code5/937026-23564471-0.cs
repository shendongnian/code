    void textBox1_TextChanged(object sender, EventArgs e)
    {
        if(ListBox1.Items.Cast<object>().Any(TextBox1.Text))
        {
             MessageBox.Show("Message");
        }
    }
