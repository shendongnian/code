    private void saveTiff_Click(List<Image> imgList, string saveName,  int dpi)
    {
        //all kudos to : http://bobpowell.net/generating_multipage_tiffs.aspx
        foreach (Image img in imgList) ((Bitmap)img).SetResolution(dpi, dpi);
        System.Drawing.Imaging.Encoder enc = System.Drawing.Imaging.Encoder.SaveFlag;
        Bitmap master = new Bitmap(imgList[0]);
        master.SetResolution(dpi, dpi);
        ImageCodecInfo info = null;
        // lets hope we have an TIF encoder
        foreach (ImageCodecInfo ice in ImageCodecInfo.GetImageEncoders())
            if (ice.MimeType == "image/tiff")  info = ice;
        // one parameter: MultiFrame
        EncoderParameters ep = new EncoderParameters(1);
        ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.MultiFrame);
        master.Save(saveName, info, ep);
        // one parameter: further frames
        ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.FrameDimensionPage);
        for (int i = 1; i < imgList.Count; i++)  master.SaveAdd(imgList[i], ep);
        // one parameter: flush
        ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.Flush);
        master.SaveAdd(ep);
    }
