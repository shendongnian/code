    public static int[] TryParseIntArray(this string source, char separator = ',')
    {
       int[] arrInt;
                
       try
         {
           arrInt = Array.ConvertAll(source.Split(separator), int.Parse);          
         }
       catch (Exception ex)
         {
           arrInt = new int[] { 0 };
         }
                
      return arrInt;
    }
