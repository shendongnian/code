    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
     {
    if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
     {
      e.Handled = false;
     }
     else
     {
        e.Handled = true;
     }
    }
