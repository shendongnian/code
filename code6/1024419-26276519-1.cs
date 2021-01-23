    private void button1_Paint(object sender, PaintEventArgs e)
    {
      // the background image
      e.Graphics.DrawImage(button1.BackgroundImage, Point.Empty);
      // maybe a few borderlines ?
      using (Pen penbright = new Pen(Color.FromArgb(155,255,255,255)))
           e.Graphics.DrawRectangle(penbright, button1.ClientRectangle);
      using (Pen pendark = new Pen(Color.FromArgb(155, 0, 0, 0)))
           e.Graphics.DrawRectangle(pendark, 
                                    new Rectangle(new Point(-1,-1), button1.ClientSize));
      // Now the Text: Stroke: white over black 
      e.Graphics.DrawString(button1.Text, button1.Font, Brushes.Black, new Point(10,10));
      e.Graphics.DrawString(button1.Text, button1.Font, Brushes.White, new Point(11,11));
    }
