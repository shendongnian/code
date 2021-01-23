    public static Stream DownloadFile(string TargetFile)
    {
        WebClient MyWebClient = new WebClient();
        byte[] BytesFile = MyWebClient.DownloadData(TargetFile);
    
        MemoryStream iStream = new MemoryStream(BytesFile);
    
        return iStream;
    }
