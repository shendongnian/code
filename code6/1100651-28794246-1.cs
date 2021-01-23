    void maskedTextBox1_TextChanged(object sender, System.EventArgs e)
    {
        string input = this.maskedTextBox1.Text;
        StringBuilder outputBuilder = new StringBuilder(input.Length);
        char[] allowedCharacters = new char[] { '|', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
        foreach (char c in input)
        {
            if (allowedCharacters.Contains(c))
            {
                outputBuilder.Append(c);
            }
        }
        string output = outputBuilder.ToString();
        if (!input.Equals(output))
        {
            this.maskedTextBox1.Text = output;
        }
    }
