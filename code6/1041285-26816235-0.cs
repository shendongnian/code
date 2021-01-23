    private void yourbutton_Paint(object sender, PaintEventArgs e)
    {
        // base.OnPaint(e);     optional
        Rectangle rc = yourButton.ClientRectangle;
        Rectangle ri = new Rectangle(Point.Empty, yourButton.BackgroundImage.Size);
        // e.Graphics.FillRectangle(SystemBrushes.Control, rc);  optional
        e.Graphics.DrawImage(yourButton.BackgroundImage, rc, ri, GraphicsUnit.Pixel);
        e.Graphics.DrawString(yourButton.Text, yourButton.Font, 
                              SystemBrushes.ControlText, Point.Empty);   // if needed
    }
