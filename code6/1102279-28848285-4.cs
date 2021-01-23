    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
      char c= e.KeyChar;
      bool comma= textBox1.Text.Contains(','); //true in case comma already inserted
    
      // accepts only digits, controls and comma
      if (!char.IsDigit(c) && !char.IsControl(c) && c!=',')
      {
        e.Handled = true;
      }
    
    
      // whenever a comma is inserted we check if we already have one
      if (c == ',' && comma)
      {
        e.Handled = true;
      }
    }
