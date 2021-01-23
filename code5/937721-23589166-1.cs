    public static bool IsPathWithinLimits (string fullPathAndFilename)
    {
         const int MAX_PATH_LENGTH = 260;
         return fullPathAndFilename.Length<=MAX_PATH_LENGTH;
    }
