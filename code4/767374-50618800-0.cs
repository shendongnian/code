    e.Graphics.Clear(BackColor);
    using (var drawBrush = new SolidBrush(ForeColor))
    using (var sf = new StringFormat
    {
        Alignment = StringAlignment.Center,
        LineAlignment = StringAlignment.Center
    })
    {
        e.Graphics.DrawString(Text, Font, drawBrush, ClientRectangle, sf);
    }
