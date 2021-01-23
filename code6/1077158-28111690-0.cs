    if (System.IO.File.Exists(outputTif))
       System.IO.File.Delete(outputTif);
    Bitmap img = new Bitmap(inputTif);
    Bitmap multiPageImage = (Bitmap)img.Clone();
    multiPageImage.SelectActiveFrame(FrameDimension.Page, 0);
    Bitmap firstPage = new Bitmap(multiPageImage.Width, multiPageImage.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
    Graphics g = Graphics.FromImage(firstPage);
    g.DrawImageUnscaled(multiPageImage, 0, 0);
    g.Dispose();
    ImageCodecInfo TiffCodec = null;
    foreach (ImageCodecInfo codec in ImageCodecInfo.GetImageEncoders())
       if (codec.MimeType == "image/tiff")
       {
          TiffCodec = codec;
          break;
       }
    EncoderParameters parameters = new EncoderParameters(2);
    parameters.Param[0] = new EncoderParameter(Encoder.SaveFlag, (long)EncoderValue.MultiFrame);
    parameters.Param[1] = new EncoderParameter(Encoder.ColorDepth, (long)24);
    //save the first page in a new file
    firstPage.Save(outputTif, TiffCodec, parameters);
    parameters = new EncoderParameters(2);
    parameters.Param[0] = new EncoderParameter(Encoder.SaveFlag, (long)EncoderValue.FrameDimensionPage);
    parameters.Param[1] = new EncoderParameter(Encoder.ColorDepth, (long)24);
    var pageCount = multiPageImage.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);
    //now append pages from second to last
    for (int i = 1; i < pageCount; ++i)
    {
       multiPageImage = (Bitmap)img.Clone();
       multiPageImage.SelectActiveFrame(FrameDimension.Page, i);
       Bitmap nextPage = new Bitmap(multiPageImage.Width, multiPageImage.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
       g = Graphics.FromImage(nextPage);
       g.DrawImageUnscaled(multiPageImage, 0, 0);
       g.Dispose();
       firstPage.SaveAdd(nextPage, parameters);
       nextPage.Dispose();
    }
    parameters = new EncoderParameters(2);
    parameters.Param[0] = new EncoderParameter(Encoder.SaveFlag, (long)EncoderValue.Flush);
    parameters.Param[1] = new EncoderParameter(Encoder.SaveFlag, (long)EncoderValue.LastFrame);
    firstPage.SaveAdd(parameters);
    firstPage.Dispose();
