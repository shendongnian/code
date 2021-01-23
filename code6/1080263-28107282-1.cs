    var input = "abcdefghijklmnop";
    byte[] output;
    using (var ms = new MemoryStream())
    using (var cs = new CryptoStream(ms, new FromBase64Transform(), CryptoStreamMode.Write))
    using (var tr = new StreamWriter(cs))
    {
        tr.Write(input);
        tr.Flush();
        output = ms.ToArray();
    }
