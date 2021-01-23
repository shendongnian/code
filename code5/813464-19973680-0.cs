    // Our text to paint
    String str = "This is my text.";
    // Create our new bitmap object
    Bitmap bmp = new Bitmap(128, 128);
    Image img = Image.FromHbitmap(bmp.GetHbitmap());
    // Get our graphics object
    Graphics g = Graphics.FromImage(img);
    g.Clear(Color.White);
    // Define our image padding
    var imgPadding = new Rectangle(2, 2, 2, 2);
    // Determine the size of our text, using our specified font.
    Font ourFont = new Font(
        FontFamily.GenericSansSerif,
        12.0f,
        FontStyle.Regular,
        GraphicsUnit.Point
    );
    SizeF strSize = g.MeasureString(
        str,
        ourFont,
        (bmp.Width - imgPadding.Left - imgPadding.Right),
        StringFormat.GenericDefault
    );
    // Create our brushes
    SolidBrush textBrush = new SolidBrush(Color.DodgerBlue);
    // Draw our string to the bitmap using our graphics object
    g.DrawString(str, ourFont, textBrush, imgPadding.Left, imgPadding.Top);
    // Flush
    g.Flush(System.Drawing.Drawing2D.FlushIntention.Sync);
    // Save our image.
    img.Save("myImage.png", System.Drawing.Imaging.ImageFormat.Png);
    // Clean up
    textBrush.Dispose();
    g.Dispose();
    bmp.Dispose();
