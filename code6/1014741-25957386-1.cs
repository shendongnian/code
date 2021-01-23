    private void MouseMove(object sender, MouseEventArgs e)
    {
      Label L = (Label)sender;
      Rectangle PR = L.Parent.ClientRectangle;
 
      if (e.Button == MouseButtons.Left)
      {
         L.Left = Math.Min(Math.Max(0, e.X + L.Left - startposition.X), PR.Right - L.Width);
         L.Top = Math.Min( Math.Max(0, e.Y + L.Top - startposition.Y), PR.Bottom - L.Height);
      }
    }
