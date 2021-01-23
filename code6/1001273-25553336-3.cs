    using System.Drawing.Imaging;
    // ..
    System.Drawing.Imaging.Encoder enc = System.Drawing.Imaging.Encoder.SaveFlag;
    // create one master bitmap from the first image
    Bitmap master = new Bitmap(imgList[0]);
    ImageCodecInfo info = null;
    
    // lets hope we find a tiff encoder!
    foreach (ImageCodecInfo ice in ImageCodecInfo.GetImageEncoders())
        if (ice.MimeType == "image/tiff")  info = ice;
    // we'll always need only one parameter
    EncoderParameters ep = new EncoderParameters(1);
    ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.MultiFrame);
    // save the master with our parameter, announcing it will be 'MultiFrame'
    master.Save(saveName, info, ep);
    // now change the parameter to 'FramePage'..
    ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.FrameDimensionPage);
    // ..and add-save the other images into the master file
    for (int i = 1; i < imgList.Count; i++)
        master.SaveAdd(imgList[i], ep);
    // finally set the parameter to 'Flush' and do it..
    ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.Flush);
    master.SaveAdd(ep);
