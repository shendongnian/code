    private void button5_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.Clear(button5.BackColor);  // omit or change  appropriately!
        Color c1 = Color.Red;
        Color c2 = Color.BlueViolet;
        using (Brush b = new System.Drawing.Drawing2D.LinearGradientBrush(
                             e.ClipRectangle, c1, c2, 10))
        {
            GraphicsPath GP = new GraphicsPath();
            GP.AddEllipse(e.ClipRectangle);
            e.Graphics.Clip = new System.Drawing.Region(GP);
            e.Graphics.FillRectangle(b, e.ClipRectangle);
        }
    }
