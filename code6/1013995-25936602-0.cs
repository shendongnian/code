    // using System.Net.Http;
    private static async Task<IRandomAccessStream> _DownloadImage2(string url)
    {
        HttpClient http = new HttpClient();
        var httpStream = await http.GetStreamAsync(url);
        var stream = new InMemoryRandomAccessStream();
        Stream streamForWrite = stream.AsStreamForWrite();
        await httpStream.CopyToAsync(streamForWrite);
        stream.Seek(0);
        Debug.WriteLine("Length: " + streamForWrite.Length);
        Debug.WriteLine("Size: " + stream.Size);
        return stream;
    }
