    private static Encoding asciiEncoding;
    public static Encoding ASCII
    {
        get
        {
            if (asciiEncoding == null)
            {
                asciiEncoding = new ASCIIEncoding();
            }
            return asciiEncoding;
        }
    }
