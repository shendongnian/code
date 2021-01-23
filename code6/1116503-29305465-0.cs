    public static void InsertSQLData([BlobTrigger("blobcontainer/{name}")] Stream input,
                                     string name, TextWriter log)
    {
        // ...
        log.WriteLine("some message");
    }
