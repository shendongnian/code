    public string GenerateRandomCode(int length)
    {
        var chars = "ABCDEF1234567890";
        var random = new Random();
        return new string(
            Enumerable.Repeat(chars, length)
                  .Select(s => s[random.Next(s.Length)])
                  .ToArray()
        );
    }
    private void button1_Click(object sender, EventArgs e)
    {
        textBox1.Text = GenerateRandomCode(11);
    }
