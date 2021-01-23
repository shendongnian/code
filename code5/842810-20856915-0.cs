    public static double ConvertDegreeAngleToDouble(double degrees, double minutes, double seconds, ExifGpsLatitudeRef   exifGpsLatitudeRef)
    {
        double result = ConvertDegreeAngleToDouble(degrees, minutes, seconds);
        if (exifGpsLatitudeRef == ExifGpsLatitudeRef.South)
        {
            result = -1*result;
        }
        return result;
    }               
    public static double ConvertDegreeAngleToDouble(double degrees, double minutes, double seconds)
    {            
        return degrees + (minutes/60) + (seconds/3600);
    }
