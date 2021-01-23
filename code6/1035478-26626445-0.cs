    private bool dot = false;
    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (System.Char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == '.' || e.KeyChar == 13)
      {
        if (e.KeyChar == '.')
        {
          if (!dot)
          {
            dot = true;
            e.Handled = false;
          }
          else
            e.Handled = true;
        }
        else
        {
          e.Handled = false;
        }
      }
      else if (e.KeyChar == ',')
      {
        e.Handled = true;
      }
    }
