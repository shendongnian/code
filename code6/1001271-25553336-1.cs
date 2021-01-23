    System.Drawing.Imaging.Encoder enc = System.Drawing.Imaging.Encoder.SaveFlag;
    // create one master bitmap from the first image
    Bitmap master = new Bitmap(imgList[0]);
    ImageCodecInfo info = null;
    foreach (ImageCodecInfo ice in ImageCodecInfo.GetImageEncoders())
        if (ice.MimeType == "image/tiff")  info = ice;
    EncoderParameters ep = new EncoderParameters(1);
    ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.MultiFrame);
    // save the master with one parameter, announcing it will be 'MultiFrame'
    master.Save(saveName, info, ep);
    ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.FrameDimensionPage);
    // now add-save the other images into the master file
    for (int i = 1; i < imgList.Count; i++)
        master.SaveAdd(imgList[i], ep);
    ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.Flush);
    master.SaveAdd(ep);
