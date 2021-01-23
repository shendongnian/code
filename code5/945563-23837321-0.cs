    public Stream CompressStreams(IList<Stream> Streams, IList<string> StreamNames, Stream OutputStream = null)
        {
            MemoryStream Response = new MemoryStream();
            using (ZipArchive ZippedFile = new ZipArchive(Response, ZipArchiveMode.Create, true))
            {
                for (int i = 0, length = Streams.Count; i < length; i++)
                    using (var entry = ZippedFile.CreateEntry(StreamNames[i]).Open())
                    {
                        Streams[i].CopyTo(entry);
                    }
            }
            if (OutputStream != null)
            {
                Response.Seek(0, SeekOrigin.Begin);
                Response.CopyTo(OutputStream);
            }
            return Response;
        }
