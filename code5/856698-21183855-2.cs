    private static byte[] GetByteArrayFromHexString(string input)
    {
        return input
            .Split(new[] { ',',' ','\t' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(i => i.Trim().Replace("0x", ""))
            .Select(i => Convert.ToByte(i, 16))
            .ToArray();
    }
