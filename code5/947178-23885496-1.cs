    string msg = "You Must be from South Carolina!";
    Font stringFont = new Font("Arial", 12);
    using (Bitmap tempImage = new Bitmap(400,400)) 
    {
        SizeF stringSize = Graphics.FromImage(tempImage).MeasureString(msg , stringFont);
        double width = stringSize.Width;
    }
   
