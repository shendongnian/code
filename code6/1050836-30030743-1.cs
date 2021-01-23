    public static IEnumerable<FileInfo> DownloadAttachments(this EmailClient client, IMessageSummary message,
        string destination)
    {
        fileNameFilter = fileNameFilter ?? AlwaysTrue;
        if (!Directory.Exists(destination))
            Directory.CreateDirectory(destination);
        var folder = client.Inbox;
        folder.Open(FolderAccess.ReadOnly);
        foreach (var part in message.Body.GetBasicBodyParts())
        {
            
            var mimeHeader = (MimePart) folder.GetBodyPart(message.UniqueId.Value, part, headersOnly: true);
            var headerFileName = mimeHeader.FileName;
            if (string.IsNullOrWhiteSpace(headerFileName))
                continue;
            var mime = (MimePart) folder.GetBodyPart(message.UniqueId.Value, part);
            var fileName = mime.FileName;
            var filePath = Path.Combine(destination, fileName);
            using (var stream = File.Create(filePath))
                mime.ContentObject.DecodeTo(stream);
            yield return new FileInfo(filePath);
        }
    }
