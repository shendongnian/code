    // first convert from byte[] to pointer
    IntPtr pData = Marshal.AllocHGlobal(imgData.Length);
    Marshal.Copy(imgData, 0, pData, imgData.Length);
    int bytesPerLine = (imgWidth + 31) / 32 * 4; //stride must be a multiple of 4. Make sure the byte array already has enough padding for each scan line if needed
    System.Drawing.Bitmap img = new Bitmap(imgWidth, imgHeight, bytesPerLine, PixelFormat.Format1bppIndexed, pData);
    
    ImageCodecInfo TiffCodec = null;
    foreach (ImageCodecInfo codec in ImageCodecInfo.GetImageEncoders())
       if (codec.MimeType == "image/tiff")
       {
          TiffCodec = codec;
          break;
       }
    EncoderParameters parameters = new EncoderParameters(2);
    parameters.Param[0] = new EncoderParameter(Encoder.Compression, (long)EncoderValue.CompressionLZW);
    parameters.Param[1] = new EncoderParameter(Encoder.ColorDepth, (long)1);
    img.Save("OnebitLzw.tif", TiffCodec, parameters);
    
    parameters.Param[0] = new EncoderParameter(Encoder.Compression, (long)EncoderValue.CompressionCCITT4);
    img.Save("OnebitFaxGroup4.tif", TiffCodec, parameters);
    
    parameters.Param[0] = new EncoderParameter(Encoder.Compression, (long)EncoderValue.CompressionNone);
    img.Save("OnebitUncompressed.tif", TiffCodec, parameters);
    
    img.Dispose();
    Marshal.FreeHGlobal(pData); //important to not get memory leaks
