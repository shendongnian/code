    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
       char c= e.KeyChar;
       if (!char.IsDigit(c) && !char.IsControl(c))
       {
          e.Handled = true;
        }
    }
