     public unsafe void OverlayImage3(Bitmap overlay, Bitmap background, Bitmap output)
     {
        Rectangle lrEntire = new Rectangle(new Point(), background.Size);
        BitmapData bdBack = background.LockBits(lrEntire, 
                   ImageLockMode.ReadOnly, background.PixelFormat);
        BitmapData bdOverlay = overlay.LockBits(lrEntire, 
                   ImageLockMode.ReadOnly, overlay.PixelFormat);
        BitmapData bdOut = output.LockBits(lrEntire, 
                   ImageLockMode.WriteOnly, output.PixelFormat);
        byte* pBack    = (byte*)bdBack.Scan0;
        byte* pOverlay = (byte*)bdOverlay.Scan0;
        byte* pOut     = (byte*)bdOut.Scan0;
        for (int luiToProcess = (bdBack.Height * bdBack.Stride) >> 2; 
                                 luiToProcess > 0; luiToProcess--)
        {
            //get each pixel component
            byte red   = *(pBack + 2); 
            byte green = *(pBack + 1); 
            byte blue  = *(pBack + 0); 
            byte oalpha = *(pOverlay + 3);
            byte ored   = *(pOverlay + 2); 
            byte ogreen = *(pOverlay + 1); 
            byte oblue  = *(pOverlay + 0);
            //get each pixel color component
            byte rOut, gOut, bOut;
            if (oalpha == 255) 
            {   rOut = ored;  gOut = ogreen;    bOut = oblue;   }
            else if (oalpha == 0)
            {   rOut = red;   gOut = green;     bOut = blue;    }
            else
            {
                rOut = (byte)((red * (255 - oalpha) + (ored * oalpha)) / 255);
                gOut = (byte)((green * (255 - oalpha) + (ogreen * oalpha)) / 255);
                bOut = (byte)((blue * (255 - oalpha) + (oblue * oalpha)) / 255);
            }
            *(pOut + 3) = 0xff;
            *(pOut + 2) = rOut;
            *(pOut + 1) = gOut;
            *(pOut + 0) = bOut;
            //move to the next pixel
            pBack += 4;   pOverlay += 4;  pOut += 4;
        }
