    public static byte[] CreateTimestamp(string Etag)
    {
        var timestamp = new List<byte>();
        var strippedEtag = Etag.Split('\'')[1];
        var byteStrings = Enumerable.Range(0, strippedEtag.Length / 2).Select(i => strippedEtag.Substring(i * 2, 2)).ToList();
        return Enumerable.Range(0, strippedEtag.Length)
                      .Where(x => x % 2 == 0)
                      .Select(x => Convert.ToByte(strippedEtag.Substring(x, 2), 16))
                      .ToArray();
     }
