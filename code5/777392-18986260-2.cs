    public ActionResult MyAction()
    {
        string base64String = // get from Linux system
        byte[] zipBytes = Convert.FromBase64String(base64String);
        using (var zipStream = new MemoryStream(zipBytes))
        using (var zipArchive = new ZipArchive(zipStream))
        {
            var entry = zipArchive.Entries.Single();
            string mimeType = MimeMapping.GetMimeMapping(entry.Name);
            using (var decompressedStream = entry.Open())
                return File(decompressedStream, mimeType);
        }
    }
