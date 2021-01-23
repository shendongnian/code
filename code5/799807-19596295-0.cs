    private void button_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(TextBox.Text))
            {
                MessageBox.Show("Please drag a file to the Tex Box!");
                return; // return from the event
            }
        File.Copy(TextBox.Text, "C:/");
    }
