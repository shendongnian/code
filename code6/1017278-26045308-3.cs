    private void textBox7_TextChanged(object sender, EventArgs e)
    {
        StringBuilder builder = new StringBuilder()
        string trimmed = textBox7.Text.Trim();
        for(int i=0; i<trimmed.Length; i++)
        {
            char c = trimmed.Text[i];
            if(char.IsDigit(c) || (i==0 && c=='-'))
            {
                builder.Append(c);
            }
        }
        textBox7.Text = builder.ToString();
    }
