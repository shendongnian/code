    System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(800, 1000); //Creates Bitmap
    using(Graphics g = Graphics.FromImage(bitmap))
    {
       RectangleF rect = new RectangleF(new PointF(0, 700), new SizeF(200,200)); // adjust these accordingly for your bounding rect
       StringFormat drawFormat = new StringFormat();
       drawFormat.Alignment = StringAlignment.Near;
       g.DrawString("Comment: " + CommentBox.Text, outputFont, Brushes.Black, rect, drawFormat); // Writing the text from the comment box on to the Tiff file.
    }
