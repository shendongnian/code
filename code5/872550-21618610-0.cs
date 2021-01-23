    private void richTextBox1_TextChanged(object sender, EventArgs e)
    {
        string[] splitNewlines = richTextBox1.Text.Split('\n');
        string newText = "";
        foreach (string s in splitNewlines)
        {
            if (!string.IsNullOrWhiteSpace(s))
                newText += s + "." + "\n";
            else
                newText += "\n";
        }
        richTextBox2.Text = newText;
    }
