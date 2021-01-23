    public string GenerateRandomCode(int length)
    {
        string charPool = "ABCDEF1234567890";
        StringBuilder rs = new StringBuilder();
        Random random = new Random();
    
        for (int i = 0; i < length; i++)
        {
            rs.Append(charPool[(int)(random.NextDouble() * charPool.Length)]);
        }
        return rs.ToString();
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        textBox1.Text = "00000001008" + GenerateRandomCode(1);
    }
