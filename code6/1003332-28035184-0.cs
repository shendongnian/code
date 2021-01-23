    JpegBitmapDecoder decoder = new JpegBitmapDecoder(stream, BitmapCreateOptions.None, BitmapCacheOption.None);
    BitmapMetadata meta = (BitmapMetadata)decoder.Frames[0].Metadata;
    ulong[] latitude = meta.GetQuery("/app1/ifd/gps/subifd:{ulong=2}") as ulong[];
    ulong[] longitude = meta.GetQuery("/app1/ifd/gps/subifd:{ulong=4}") as ulong[];
    double lat = ConvertCoordinate(latitude);
    double longit = ConvertCoordinate(longitude);
    static double ConvertCoordinate(ulong[] coordinates)
    {
    int lDash = (int)(coordinates[0] - ((ulong)0x100000000));
    int lF = (int)(coordinates[1] - ((ulong)0x100000000));
    double lR = ((double)(coordinates[2] - ((ulong)0x6400000000))) / 100;
    double tRes = (lDash + (((double)lF) / 60)) + (lR / 3600);
    return (Math.Floor((double)(tRes * 1000000)) / 1000000);
    }
