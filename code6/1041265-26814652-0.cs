       Dim source As BitmapSource
       Using raster As RasterImage = RasterImageConverter.ConvertFromSource(bitmap, ConvertFromSourceOptions.None)
          Console.WriteLine("Converted to RasterImage, bits/pixel is {0} and order is {1}", raster.BitsPerPixel, raster.Order)
    
          ' Perform image processing on the raster image using LEADTOOLS
          Dim cmd As New FlipCommand(False)
          cmd.Run(raster)
    
          ' Convert the image back to WPF using default options
          source = DirectCast(RasterImageConverter.ConvertToSource(raster, ConvertToSourceOptions.None), BitmapSource)
       End Using
