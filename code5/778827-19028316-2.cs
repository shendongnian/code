    public IEnumerable<Stream> UnZipObject(Stream data)
    {
        using (var zip = ZipFile.Read(data))
        {
            foreach (var item in zip)
            {
                var newStream = new MemoryStream();
                item.Extract(newStream);
                newStream.Position = 0;
                yield return newStream;
            }
        }
    }
