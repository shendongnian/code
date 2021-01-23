    private void textBox_KeyPress(object sender, KeyPressEventArgs e)
    {
       if ((label.Text.Equals("gms") || label.Text.Equals("rs") || label.Text.Equals("knot"))
       { 
          if (!char.IsDigit(e.KeyChar))
          {
             e.Handled = true;
          }
       }
       else
       {
          if (!char.IsLetter(e.KeyChar))
          {
             e.Handled = true;
          }
       }
    }
