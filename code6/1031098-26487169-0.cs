    double dbl = (double)image.Width / (double)image.Height;
    if( (int)((double)boxHeight * dbl) <= boxWidth )
    {
        resizedImage = new Bitmap(original, (int)((double)boxHeight * dbl), boxHeight);
    }
    else
    {
        resizedImage = new Bitmap(original, boxWidth, (int)((double)boxHeight / dbl) );
    }
