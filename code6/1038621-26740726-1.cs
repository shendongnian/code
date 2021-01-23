    private void cb_saveTiff_Click(object sender, EventArgs e)
    {
        //all kudos to : http://bobpowell.net/generating_multipage_tiffs.aspx
        string saveName = yourOutFileName;
        int dpi = yourDPI;
        List<Image> imgList = new List<Image>();
        foreach (Image img in imageList1.Images)
        {
            ((Bitmap)img).SetResolution(dpi, dpi);
            imgList.Add(img);
        }
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
        for (int i = 1; i < imgList.Count; i++)
            master.SaveAdd(imgList[i], ep);
        // one parameter: flush
        ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.Flush);
        master.SaveAdd(ep);
    }
