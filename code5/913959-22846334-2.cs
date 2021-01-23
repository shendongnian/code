    private static volatile Encoding utf8Encoding;
    public static Encoding UTF8 
    {
         get 
         {
             if (utf8Encoding == null) 
                 utf8Encoding = new UTF8Encoding(true);
             return utf8Encoding;
         }
    }
 
