    public static bool operator <(FiscalSamplingPoint  point1, FiscalSamplingPoint  point2)
    {
        return point1.GetHashCode() < point2.GetHashCode();
    }
    
    public static bool operator > (FiscalSamplingPoint  point1, FiscalSamplingPoint  point2)
    {
         return point1.GetHashCode() > point2.GetHashCode();
    }
