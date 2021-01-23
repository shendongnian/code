    using (MemoryStream base64Stream = new MemoryStream(base64byteArray))
    {
        using (GZipStream gzip = new GZipStream(
            base64Stream, CompressionMode.Decompress))
        {
            string deserialized = Serializer.Deserialize<string>(gzip);
            Assert.IsNotNull(deserialized);
            Assert.AreEqual(data, deserialized);
        }
    }
