    gfx.PageUnit = GraphicsUnit.Inch;
    using (Pen blackPen = new Pen(Color.Black, 0.01f))
    using (Pen redPen = new Pen(Color.Red, 0.01f))
    {
        gfx.DrawRectangle(blackPen, .25f, .25f, 2, 2);
        var outerContainer = gfx.BeginContainer(
            new RectangleF(.25f, .25f, 2, 2),
            new RectangleF(0, 0, 2 * 25.4f, 2 * 25.4f),
            GraphicsUnit.Millimeter);
        gfx.PageUnit = GraphicsUnit.Millimeter;
        gfx.DrawRectangle(redPen, .25f * 25.4f, .25f * 25.4f, 1.5f * 25.4f, 1.5f * 25.4f);
        gfx.EndContainer(outerContainer);
    }
