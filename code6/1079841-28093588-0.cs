    byte[] fileData = null;
    using (var binaryReader = new BinaryReader(Request.Files[0].InputStream))
    {
        fileData = binaryReader.ReadBytes(Request.Files[0].ContentLength);
    }
    
    // pass the scanning engine
    StreamScanRequest scan = requestManagerObj.CreateStreamScanRequest(Policy.DEFAULT);
    //...
