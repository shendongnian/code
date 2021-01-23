    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      currenText = textBox1.Text;
    }
  
    private void textBox1_KeyDown(object sender, KeyPressEventArgs e))
    {
        if (e.KeyValue == 8) // backspace control
            {
                if (textBox1.Text.Length > 0)
                {
                    textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1, 1);
                }
            }
            else if (e.Control && e.KeyCode== Keys.V)
            {
                int index = textBox2.Text.IndexOf(currentText);
                textBox2.Text = textBox2.Text.Remove(index);
                textBox2.Text += textBox1.Text;
            }
            else if (char.IsLetterOrDigit((char)e.KeyValue))
            { 
                textBox2.Text += ((char)e.KeyValue).ToString().ToLower();
            }
    }
