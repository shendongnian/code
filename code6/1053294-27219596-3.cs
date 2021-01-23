    static private void button5_Click(object sender, EventArgs e)
    {
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 1; i < s.Length - 1; i += 4)
            stringBuilder.Append(s.Substring(i, 2));
        textBox6.Text = stringBuilder.ToString();
    }
