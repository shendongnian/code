    private static Random rand = new Random();
    private static string alphabet = "ABCDEFG";
    private static string GetRandomString(int length)
    {
        var stringBuilder = new StringBuilder();
        for (int i = 0; i < length; i++)
        {
            stringBuilder.Append(alphabet[rand.Next(0, alphabet.length)]);
        }
        return stringBuilder.ToString();
    }
    private void GenerateLetter_Click(object sender, EventArgs e)
    {
        textBox1.Text = GetRandomString(5);
        textBox2.Text = GetRandomString(5);
        textBox3.Text = GetRandomString(5);
        textBox4.Text = GetRandomString(5);         
    }
