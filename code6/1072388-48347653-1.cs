    private const int exifOrientationID = 0x112; //274
    
    public static void ExifRotate(this Image img)
    {
        if (!img.PropertyIdList.Contains(exifOrientationID))
            return;
    
        var prop = img.GetPropertyItem(exifOrientationID);
        int val = BitConverter.ToUInt16(prop.Value, 0);
        var rot = RotateFlipType.RotateNoneFlipNone;
    
        if (val == 3 || val == 4)
            rot = RotateFlipType.Rotate180FlipNone;
        else if (val == 5 || val == 6)
            rot = RotateFlipType.Rotate90FlipNone;
        else if (val == 7 || val == 8)
            rot = RotateFlipType.Rotate270FlipNone;
    
        if (val == 2 || val == 4 || val == 5 || val == 7)
            rot |= RotateFlipType.RotateNoneFlipX;
    
        if (rot != RotateFlipType.RotateNoneFlipNone)
            img.RotateFlip(rot);
    }
