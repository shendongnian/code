    System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(800, 1000); //Creates Bitmap
    using(Graphics g = Graphics.FromImage(bitmap))
    {
       RectangleF rect = new RectF(new PointF(0, 700), new SizeF(200,200)));
       StringFormat drawFormat = new StringFormat();
       drawFormat.Alignment = StringAlignment.Center;
       g.DrawString("Comment: " + CommentBox.Text, outputFont, Brushes.Black, rect, drawFormat); // Writing the text from the comment box on to the Tiff file.
    }
