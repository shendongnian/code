    public static byte[] CompressByGzip( byte[] input ) 
    {
       using(var ims = new MemoryStream()) 
       {
         using(var gzip = new GZipStream(ims, CompressionMode.Compress)) 
         {
            gzip.Write(input, 0, input.Length);
         }
         return ims.ToArray();
        }
     }
