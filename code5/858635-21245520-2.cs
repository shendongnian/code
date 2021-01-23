    char[] charArray = { 'x', 'x', 'x' };
    
    private void button1_Click(object sender, EventArgs e)
    {
        foreach (char c in charArray)
        {
            for (int i = 0; i < 3; i++)
                textBox.Text += c;
    
            textBox.Text += Environment.NewLine;
         }
    }
