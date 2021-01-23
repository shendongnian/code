    protected override void OnPaint(PaintEventArgs e)
    {
        var r = ClientRectangle;
        // Here you can set the size of the form to any given size
        r.Width = 120;
        r.Height -= 1;
        // Here you draw a one pixel black border
        ControlPaint.DrawBorder(e.Graphics, r, Color.Black, ButtonBorderStyle.Solid);
    }
