    private void PANELS_PARENT_CONTROL_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Location.X > pnlOne.Location.X &&
          e.Location.X < (pnlOne.Location.X + pnlOne.Width) &&
          e.Location.Y > pnlOne.Location.Y &&
          e.Location.Y < (pnlOne.Location.Y + pnlOne.Height))
        {
          pnlOne.Enabled = true;
          pnlOne.Visible = true;
        }
      else 
        {
          pnlOne.Enabled = false;
          pnlOne.Visible = false;
        }
    }
