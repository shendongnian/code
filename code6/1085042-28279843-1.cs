      // the point in the PB where we grab it:
      Point mDown;
      void imagemPictureBox_MouseDown(object sender, MouseEventArgs e)
      {
          // grab the pb
          mDown = e.Location;
      }
      void imagemPictureBox_MouseMove(object sender, MouseEventArgs e)
      {
        // new position:
        int x = imagemPictureBox.Left + e.X - mDown.X;
        int y = imagemPictureBox.Top  + e.Y - mDown.Y;
        // limit to form size:
        x = Math.Min(Math.Max(x, 0), this.ClientSize.Width -  imagemPictureBox.Width);
        y = Math.Min(Math.Max(y, 0), this.ClientSize.Height - imagemPictureBox.Height);
        // move the pb:
        imagemPictureBox.Location = new Point(x, y);
      }
      void imagemPictureBox_MouseUp(object sender, MouseEventArgs e)
      {
          //release it (optional)
          mDown = Point.Empty;
      }
