    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        var senderTextBox    = (TextBox)sender;
        var textBoxesEnabled = senderTextBox.Text.Trim().Length == 0;
        textBox2.Enabled = textBoxesEnabled;
        textBox3.Enabled = textBoxesEnabled;
        // OR
        groupBox1.Enabled = textBoxesEnabled;
    }
