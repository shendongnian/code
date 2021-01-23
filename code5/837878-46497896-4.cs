    using (var client = new HttpClient()) {
        client.Timeout = TimeSpan.FromMinutes(5);
        using (var file = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None)) {
            await client.DownloadAsync(DownloadUrl, file, progress, cancellationToken);
        }
    }
