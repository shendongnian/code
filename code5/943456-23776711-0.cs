       Image backgroundImage = (Image)bkp.Clone();
        
       using (Graphics gfx = Graphics.FromImage(backgroundImage))
       using (Pen pen = new Pen(Color.Red))
       {
          gfx.DrawRectangle(pen,
                            Convert.ToInt16(txtLeftMargin.Text),
                            Convert.ToInt16(txtTopMargin.Text),
                            Convert.ToInt16(txtHeight.Text),
                            Convert.ToInt16(txtWidth.Text));
       }
        
       pictureBox1.Image = backgroundImage;
