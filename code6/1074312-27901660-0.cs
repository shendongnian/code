    Rectangle test = new Rectangle(50, 50, 100, 100);
    using (LinearGradientBrush brush = new LinearGradientBrush(test, Color.Red, Color.Blue, 0f))
    {
        using (var pen = new Pen(brush, 8f))
        {
            pen.Alignment = PenAlignment.Inset;
            e.Graphics.DrawRectangle(pen, test);
        }
    }
