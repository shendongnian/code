    private void button1_Click(object sender, EventArgs e)
    {
       Regex emailRegex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?
                                    ^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+
                                    [a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
       if (emailRegex.IsMatch(textBox1.Text))
       {
          MessageBox.Show(textBox1.Text + "matches the expected format.", "Attention"); 
       }
    }
