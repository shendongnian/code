    [MessageHeader(MustUnderstand = true)]
    public string FileName;
    [MessageHeader(MustUnderstand = true)]
    public long Length;
    [MessageBodyMember(Order = 1)]
    public System.IO.Stream FileByteStream;
    public void Dispose()
    { 
        if (FileByteStream != null)
        {
            FileByteStream.Close();
            FileByteStream = null;
        }
    }   
}
