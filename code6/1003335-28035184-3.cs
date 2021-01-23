    static double ConvertCoordinate(ulong[] coordinates)
    {
        if (coordinates == null)
            return 0;
        double degrees = ConvertToUnsignedRational( coordinates[ 0 ] ); 
 	    double minutes = ConvertToUnsignedRational( coordinates[ 1 ] ); 
 	    double seconds = ConvertToUnsignedRational( coordinates[ 2 ] ); 
 	    return degrees + (minutes / 60.0) + (seconds / 3600); 
    }
    static double ConvertToUnsignedRational( ulong value ) 
    { 
 	    return (value & 0xFFFFFFFFL) / (double) ((value & 0xFFFFFFFF00000000L) >> 32); 
    } 
