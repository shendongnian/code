    Bitmap image = Bitmap.FromFile(oFile) as Bitmap;
    Bitmap resized = new Bitmap(image, new Size(30, 30));
    button1.Image = resized;
    button1.Text = "Button";
    button1.ImageAlign = ContentAlignment.MiddleLeft;
    button1.TextImageRelation = TextImageRelation.ImageBeforeText;
    button1.TextAlign = ContentAlignment.MiddleRight;
