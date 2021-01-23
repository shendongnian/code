    public T2 UnzipContent(byte[] data)
    {
        using(var ms = new MemoryStream(data))
        using(var zip = new ZipInputStream(ms))
        {
            var entry = zip.GetNextEntry();
            var serializer = this.GetSerializer(typeof(T2));
            return serializer.Deserialize(zip);
        }
    }
