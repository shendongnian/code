    private void button1_Click(object sender, EventArgs e)
    {
      int i, n, sum = 0;
      for (i = 1; i <= 5; i++)
      {
      using(Form2 f2 = new Form2())
      {
        if (f2.ShowDialog() == DialogResult.OK)
        {
          if(String.IsNullOrEmpty(TextBox1.Text))
          {
            TextBox1.Text = f2.Value.ToString();
          }
          else
          {
            TextBox1.Text = String.Concat(TextBox1.Text,Environment.NewLine,f2.Value.ToString());
          } 
          sum += f2.Value;
        }
      } 
      textBox1.Text = String.Format("{0}{1}sum={2}",TextBox1.Text, Environment.NewLine,sum);
    }
