    public static byte[] JoinTiffImages(
        List<byte[]> images,
        float res)
    {
        var fPage = FrameDimension.Page;
        var nearest =
            System.Drawing
                    .Drawing2D
                    .InterpolationMode
                    .NearestNeighbor;
        if (images.Count == 0)
        {
            throw new Exception(
                "Could not join an empty set of images.");
        }
        else if (images.Count == 1)
        {
            return images[0];
        }
        else
        {
            var ms = new MemoryStream();
            //get the codec for tiff files
            var info = GetTifCodecInfo();
            var ep = new EncoderParameters(2);
            ep.Param[0] = new EncoderParameter(
                System.Drawing.Imaging.Encoder.SaveFlag,
                (long)EncoderValue.MultiFrame);
            ep.Param[1] = new EncoderParameter(
                System.Drawing.Imaging.Encoder.Compression,
                (long)EncoderValue.CompressionLZW);
            using (var masterImg =
                (Bitmap)System.Drawing.Image.FromStream(
                    new MemoryStream(images[0])))
            {
                using (var resizedMaster =
                    new Bitmap(
                        (int)(masterImg.Width *
                            (res /
                                masterImg.HorizontalResolution)),
                        (int)(masterImg.Height *
                            (res /
                                masterImg.VerticalResolution))))
                {
                    resizedMaster.SetResolution(
                        res,
                        res);
                    using (var gr = Graphics.FromImage(resizedMaster))
                    {
                        gr.InterpolationMode = nearest;
                        gr.DrawImage(
                            masterImg,
                            new Rectangle(
                                0,
                                0,
                                resizedMaster.Width,
                                resizedMaster.Height),
                            0,
                            0,
                            masterImg.Width,
                            masterImg.Height,
                            GraphicsUnit.Pixel);
                    }
                    resizedMaster.Save(ms, info, ep);
                    //save the intermediate frames
                    ep.Param[0] = new EncoderParameter(
                        System.Drawing.Imaging.Encoder.SaveFlag,
                        (long)EncoderValue.FrameDimensionPage);
                    for (int i = 1; i < images.Count; i++)
                    {
                        using (var nextImg =
                            (Bitmap)System.Drawing.Image.FromStream(
                            new MemoryStream(images[i])))
                        {
                            for (int x = 0;
                                x < nextImg.GetFrameCount(fPage);
                                x++)
                            {
                                nextImg.SelectActiveFrame(fPage, x);
                                using (var resizedNext =
                                    new Bitmap(
                                        (int)(nextImg.Width *
                                            (res /
                                                nextImg.HorizontalResolution)),
                                        (int)(nextImg.Height *
                                            (res /
                                                nextImg.VerticalResolution))))
                                {
                                    resizedNext.SetResolution(
                                        res,
                                        res);
                                    using (var gr =
                                        Graphics.FromImage(resizedNext))
                                    {
                                        gr.InterpolationMode = nearest;
                                        gr.DrawImage(
                                            nextImg,
                                            new Rectangle(
                                                0,
                                                0,
                                                resizedNext.Width,
                                                resizedNext.Height),
                                            0,
                                            0,
                                            nextImg.Width,
                                            nextImg.Height,
                                            GraphicsUnit.Pixel);
                                    }
                                    resizedMaster.SaveAdd(resizedNext, ep);
                                }
                            }
                        }
                    }
                    ep.Param[0] =
                        new EncoderParameter(
                            System.Drawing.Imaging.Encoder.SaveFlag,
                            (long)EncoderValue.Flush);
                    //close out the file.
                    resizedMaster.SaveAdd(ep);
                }
                return ms.ToArray();
            }
        }
    }
    private static ImageCodecInfo GetTifCodecInfo()
    {
        foreach (var ice in ImageCodecInfo.GetImageEncoders())
        {
            if (ice.MimeType == "image/tiff")
            {
                return ice;
            }
        }
        return null;
    }
