    using System.Drawing;
    
    Bitmap img = new Bitmap("*imagePath*");
    for (int i = 0; i < img.GetWidth; i++)
    {
        for (int j = 0; j < img.GetHeight; j++)
        {
            Color pixel = img.GetPixel(i,j);
    
            if (pixel == *your color*)
            {
                //do what you want to if you have found the pixel
            }
        }
    } 
