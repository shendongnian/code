    Size size = TextRenderer.MeasureText(g,
                                         "Ala ma kota",
                                         font,
                                         new Size(int.MaxValue, int.MaxValue),
                                         TextFormatFlags.NoPadding);
    
    TextRenderer.DrawText(g, "Ala ma kota", font,
                          new Point(10, 10),
                          Color.Black,
                          TextFormatFlags.NoPadding);
    g.DrawRectangle(Pens.Red, new Rectangle(new Point(10, 10), size));
