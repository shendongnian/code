    public void PutBytesOnClipboardRaw(Byte[] byteArr)
    {
        DataObject data = new DataObject();
        using (MemoryStream memStream = new MemoryStream())
        {
            memStream.Write(byteArr, 0, byteArr.Length);
            data.SetData("rawbinary", false, memStream);
            // The 'copy=true' argument means the MemoryStream
            // can be safely disposed after the operation.
            Clipboard.SetDataObject(data, true);
        }
    }
