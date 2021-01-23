    private void button1_Click(object sender, EventArgs e)
    {
      string[] parts = textBox1.Text.Split('+');
      int intSum = 0;
      foreach (string item in parts)
      {
        intSum = intSum + Convert.ToInt32(item);
      }
      textBox2.Text = intSum.ToString();
    }
