    public Byte[] GetBytesFromClipboard()
    {
        DataObject retrievedData = Clipboard.GetDataObject() as DataObject;
        if (retrievedData == null || !retrievedData.GetDataPresent("rawbinary"))
            return null;
        MemoryStream byteStream = retrievedData.GetData("rawbinary") as MemoryStream;
        if (byteStream == null)
            return null;
        return byteStream.ToArray();
    }
