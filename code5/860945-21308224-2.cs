    //Create String-Array
    string[] a = {"A", "B", "C"};
    
    //Create a Image-Object on which we can paint
    Image bmp = new Bitmap(100, 100);
    
    //Create the Graphics-Object to paint on the Bitmap
    Graphics g = Graphics.FromImage(bmp);
    
    //Here we get the random string
    //Random.Next() gives us the next integer value
    //Because we dont want to get IndexOutOfBoundException we give the Array length to the Next method
    //So just the numbers from 0 - Array.Length can be choosen from Next method
    string randomString = a[new Random().Next(a.Length)];
    //Your custom Font (6f = 6px)!
    Font myFont = new Font("Arial", 6f)
    //Get the perfect Image-Size so that Image-Size = String-Size
    SizeF size = g.MeasureString(randomText, myFont);
    PointF rect = new PointF(size.Width, size.Height);    
    //Use this to become better Text-Quality on Bitmap.
    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
    
    //Here we draw the string on the Bitmap
    g.DrawString(randomString, myFont, new SolidBrush(Color.Black), rect);
