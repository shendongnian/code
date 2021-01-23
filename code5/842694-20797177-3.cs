    public string GenerateRandomCode()
    {
        return "00000001008" + string.Format("{0:X1}", new Random().Next(12) + 3));
    }
    private void button1_Click(object sender, EventArgs e)
    {
        textBox1.Text = GenerateRandomCode();
    }
