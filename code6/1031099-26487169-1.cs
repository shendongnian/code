    //calculate the ratio
    double dbl = (double)image.Width / (double)image.Height;
    //set height of image to boxHeight and check if resulting width is less than boxWidth, 
    //else set width of image to boxWidth and calculate new height
    if( (int)((double)boxHeight * dbl) <= boxWidth )
    {
        resizedImage = new Bitmap(original, (int)((double)boxHeight * dbl), boxHeight);
    }
    else
    {
        resizedImage = new Bitmap(original, boxWidth, (int)((double)boxWidth / dbl) );
    }
