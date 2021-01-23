    using (var ms = new MemoryStream())
    {
        using (var zipArchive = new ZipArchive(ms, ZipArchiveMode.Create, true))
        {
            foreach (var attachment in attachmentFiles)
            {
                var entry = zipArchive.CreateEntry(attachment.FileName, CompressionLevel.Fastest);
                using (var entryStream = entry.Open())
                {
                    attachment.InputStream.CopyTo(entryStream);
                }
            }
        }
        ...
    }
