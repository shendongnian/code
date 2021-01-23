    public static void SaveImageAs(string sourcePath, string targetPath, string caption)
    {
        BitmapFrame frame;
        using (var stream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            var decoder = new JpegBitmapDecoder(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            frame = decoder.Frames[0];
        }
        if (!string.IsNullOrWhiteSpace(caption))
        {
            frame = BitmapFrame.Create(frame);
            var metadata = frame.Metadata as BitmapMetadata;
            metadata.SetQuery("/app1/ifd/{uint=270}", caption);
            metadata.SetQuery("/app13/irb/8bimiptc/iptc/Caption", caption);
            //metadata.SetQuery("/xmp/dc:description/x-default", caption);
        }
        var encoder = new JpegBitmapEncoder();
        encoder.Frames.Add(frame);
        using (var stream = new FileStream(targetPath, FileMode.Create))
        {
            encoder.Save(stream);
        }
    }
