    private string Convert(string value)
    {
        var invertedBytes = Encoding.Unicode.GetBytes(value).Select(b => (byte)~b).ToArray();
        return Encoding.Unicode.GetString(invertedBytes);
    }
