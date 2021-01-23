    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            textBox1.Text =  (Double.Parse(textBox1.Text) * 0.88).ToString(); // 0.88 EUR = 1 USD
        }
        catch { }
    }
