    Image bmp = new Bitmap(20, 20);
    using (Graphics g = Graphics.FromImage(bmp))
    {
       g.FillRectangle(new SolidBrush(Color.Red), new Rectangle(3, 3, 8, 8));
    }
    bmp.Save("test.bmp");
