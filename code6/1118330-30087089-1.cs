    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        int tester = 0;
        try
        {
            if (textBox1.Text != null)
            {
                tester = Convert.ToInt32(textBox1.Text);
                if (tester >= 30)
                {
                    textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                    textBox1.Select(textBox1.Text.Length, 0);
                }
            }
         }
         catch (Exception)
         {
             if (textBox1.Text != null)
             {
                 try
                 {
                    if (textBox1.Text != null)
                    {
                        textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                        textBox1.Select(textBox1.Text.Length, 0);
                    }
                 }
                 catch (Exception)
                 {
                     textBox1.Text = null;
                 }
             }
         }
    }
