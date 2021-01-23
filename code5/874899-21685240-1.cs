    Image orgBmp = Image.FromFile(@"fname.jpg");
    var tiffEncoder = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()
                      .First(e => e.FormatDescription == "TIFF");
    EncoderParameters parameters = new EncoderParameters(1);
    parameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.ColorDepth, (long)ColorDepth.Depth8Bit);
    orgBmp.Save(@"fname.tif", tiffEncoder, parameters);
