    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      currenText = textBox1.Text;
    }
  
    private void textBox1_KeyPress(object sender, KeyPressEventArgs e))
    {
       if(e.KeyChar == (char)8) // backspace control
       {
          textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length-1,1);
       }
       else if(e.Control && e.KeyCode == Keys.V)
       {
         int index = textBox2.Text.IndexOf(currentText);
         textBox2.Text = textBox2.Text.Remove(index);
         textBox2.Text += textBox1.Text;
       }
       else {
         textBox2.Text += e.KeyChar;
       }
    }
