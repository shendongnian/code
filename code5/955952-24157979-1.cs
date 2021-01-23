    public static void SaveImageAs(string sourcePath, string targetPath, string caption)
    {
        using (var sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            var decoder = new JpegBitmapDecoder(sourceStream, BitmapCreateOptions.None, BitmapCacheOption.None);
            var frame = decoder.Frames[0];
            if (!string.IsNullOrWhiteSpace(caption))
            {
                frame = BitmapFrame.Create(frame);
                var metadata = (BitmapMetadata)frame.Metadata;
                metadata.SetQuery("/app1/ifd/{uint=270}", caption);
                metadata.SetQuery("/app13/irb/8bimiptc/iptc/Caption", caption);
                //metadata.SetQuery("/xmp/dc:description/x-default", caption);
            }
            var encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(frame);
            using (var targetStream = new FileStream(targetPath, FileMode.Create))
            {
                encoder.Save(targetStream);
            }
        }
    }
