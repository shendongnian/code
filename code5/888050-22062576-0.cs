    private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
       // Draw the background.
       e.DrawBackground();
      // Determine the forecolor based on whether or not
      // the item is selected.
      Brush brush;
      // Get the item text.
      string text = ((ComboBox)sender).Items[e.Index].ToString();
      if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
      {
        brush = Brushes.White;
      }
         // Draw the text.
        e.Graphics.DrawString(text, ((Control)sender).Font, brush, e.Bounds.X, e.Bounds.Y);
    }
