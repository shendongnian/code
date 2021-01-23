    private void button1_Click(object sender, EventArgs e)
    {
        button1.Enabled = false;
        string[] text = Parse_Text.ParseText(richTextBox1.Text, positionToSearch, currentChar);
        richTextBox2.Text = String.Join(Environment.NewLine, text);
    }
