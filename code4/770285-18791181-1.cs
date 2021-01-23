    public static void GetLines(Action<string> callback)
    {
        var encoding = new UnicodeEncoding();
        byte[] allText;
        FileStream stream = File.Open(_path, FileMode.Open);
        allText = new byte[stream.Length];
        //something like this, but does not compile in .net 3.5
        stream.ReadAsync(allText, 0, (int)allText.Length);
        stream.BeginRead(allText, 0, allText.Length, result =>
        {
            callback(encoding.GetString(allText));
            stream.Dispose();
        }, null);
    }
