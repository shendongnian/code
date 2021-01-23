    int iWidth = tiffInput.GetField(TiffTag.IMAGEWIDTH)[0].ToInt();
    int iHeight = tiffInput.GetField(TiffTag.IMAGELENGTH)[0].ToInt();
    
    int iTile_Width = inImage.GetField(TiffTag.TILEWIDTH)[0].ToInt();
    int iTile_Height = inImage.GetField(TiffTag.TILELENGTH)[0].ToInt();
    
    for (int row = 0; row < iHeight; row += iTile_Height)
    {
          for (int col = 0; col < iWidth; col += iTile_Width)
          {
              // Read the tile into an RGBA array
              if (inImage.ReadRGBATile(col, row, raster))
              {
                  Bitmap bmp = TiffDataToImage(raster, iTile_Width, iTile_Height);
                  //Collect all these images
              
              }
          }
    }
