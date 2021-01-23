      bool ctrlPressed = false;
      private void textBox1_KeyDown(object sender, KeyEventArgs e)
      {
          ctrlPressed = (Control.ModifierKeys == Keys.Control);
      }
      private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (!ctrlPressed) 
         { 
            var regex= new Regex(@"^[0-9,]*$");
            if (!regex.IsMatch(e.KeyChar.ToString()))
            {
               e.Handled = true;
            }
         }
      }
