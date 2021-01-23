    private static Size SizeCalculation(Size image, Size boundingBox)
    {       
        double widthScale = 0, heightScale = 0;
        if (image.Width != 0)
            widthScale = (double)boundingBox.Width / (double)image.Width;
        if (image.Height != 0)
            heightScale = (double)boundingBox.Height / (double)image.Height;                
    
        double scale = Math.Min(widthScale, heightScale);
    
        Size result = new Size((int)(image.Width * scale), 
                            (int)(image.Height * scale));
        return result;
    }
