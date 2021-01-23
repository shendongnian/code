    void textBox1_TextChanged(object sender, EventArgs e)
    {
        if(ListBox1.Items.Cast<string>().Any(x => x == TextBox1.Text))
        {
             MessageBox.Show("Message");
        }
    }
