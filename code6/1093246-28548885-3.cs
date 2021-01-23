    Bgra tmp;
    Bgra save;
    
    for (int ii = 0; ii < img.Height; ii++)
    {
        for (int jj = 0; jj < img.Width; jj++)
        {
            tmp = img[ii,jj];
            save = tmp;
    
            // Red channel.
    
            if (tmp.Red == 255)
            {
                tmp.Blue = tmp.Green = 255;
            }
            else
                if (tmp.Red == 0)
                {
                    tmp.Blue = tmp.Green = 0;
                }
                else
                    if (tmp.Red < 128)
                    {
                        tmp.Blue = tmp.Green = tmp.Red / 2;
                    }
    
            red[ii, jj] = tmp;
    
            // Green channel.
    
            tmp = save;
    
            if (tmp.Green == 255)
            {
                tmp.Blue = tmp.Red = 255;
            }
            else
                if (tmp.Green == 0)
                {
                    tmp.Blue = tmp.Red = 0;
                }
                else
                    if (tmp.Green < 128)
                    {
                        tmp.Blue = tmp.Red = tmp.Green / 2;
                    }
    
            green[ii, jj] = tmp;
    
            // Blue channel.
    
            tmp = save;
    
            if (tmp.Blue == 255)
            {
                tmp.Green = tmp.Red = 255;
            }
            else
                if (tmp.Blue == 0)
                {
                    tmp.Green = tmp.Red = 0;
                }
                else
                    if (tmp.Blue < 128)
                    {
                        tmp.Green = tmp.Red = tmp.Blue / 2;
                    }
    
            blue[ii, jj] = tmp;
        }
    }
