    public static double ConvertDegreeAngleToDouble(double degrees, double minutes, double seconds, string latLongRef)
    {
        double result = ConvertDegreeAngleToDouble(degrees, minutes, seconds);
        if (latLongRef == "S" || latLongRef == "W")
        {
            result *= -1;
        }
        return result;
    }
    public static double ConvertDegreeAngleToDouble(double degrees, double minutes, double seconds)
    {
        return degrees + (minutes / 60) + (seconds / 3600);
    }
