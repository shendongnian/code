    public static T DeserializeContractData<T>(HttpContext context)
    {
        var obj = new DataContractionJsonSerializer(typeof(T))
                      .ReadObject(context.Request.InputStream)
                  as T;
                  
        return obj ?? default(T);
    }
