      for (int col = 0; col < iWidth; col += iTile_Width)
      {
          // Read the tile into an RGBA array
          if (inImage.ReadRGBATile(col, row, raster))
          {
              Bitmap bmp = TiffDataToImage(raster, iTile_Width, iTile_Height);
              //Collect all these images
          
          }
      }
