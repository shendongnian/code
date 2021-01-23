    public void PutBytesOnClipboardObj(Byte[] byteArr)
    {
        DataObject data = new DataObject();
        // Can technically just be written as "SetData(byteArr)", but this is more clear.
        data.SetData(typeof(Byte[]), byteArr);
        // The 'copy=true' argument means the data will remain available
        // after the program is closed.
        Clipboard.SetDataObject(data, true);
    }
