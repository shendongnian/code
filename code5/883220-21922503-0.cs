    const string chars = "0123456789ABCDEF";
    public string ByteArrayToString(byte[] ba)
    {
        var sb = new StringBuilder(ba.Length*2);
        for (int i = 0; i < ba.Length; ++i)
        {
            if (i > 0)
                sb.Append(',');
            var b = ba[i];
            sb.Append(chars[b >> 4]);
            sb.Append(chars[b & 0x0F]);
        }
        return sb.ToString();
    }
