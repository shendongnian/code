    /// <summary>
    /// Returns true if any data currently exists in the computer clipboard in the data format specified by the dataFormat input parameter.
    /// </summary>
    public bool HasClipboardGotDataFormat(string dataFormat)
    {
        return Clipboard.ContainsData(dataFormat);
    }
