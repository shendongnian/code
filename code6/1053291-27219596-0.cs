    private void button5_Click(object sender, EventArgs e)
    {
        StringBuilder stringBuilder = new StringBuilder();
        int i = 2;
        while (i < s.Length)
        {
            stringBuilder.Append(s.Substring(i, 2));
            i += 4;
        }
        textBox6.Text = stringBuilder.ToString();
    }
