    private void listBox1_MouseDown(object sender, MouseEventArgs e)
    {
      if (Control.ModifierKeys == Keys.Control || ( Control.ModifierKeys == Keys.Control || e.Button == MouseButtons.Left))
      {
        listBox1.SelectionMode = SelectionMode.MultiExtended;
      }
      else if (e.Button == MouseButtons.Left)
      {
        listBox1.SelectionMode = SelectionMode.One;
      }
    }
