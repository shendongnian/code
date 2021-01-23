    public void FromByteArray(byte[] value)
    {
        var delimiter = (byte)'%';
        var stringBytes = value.TakeWhile(b => b != delimiter).ToArray();
        var enumByte = 0;
        if (stringBytes.Length < value.Length)
        {
            enumByte = value.Last();
        }
        TokenValue = Encoding.ASCII.GetString(stringBytes);
        TokenType = (TokenType)enumByte;
    }
