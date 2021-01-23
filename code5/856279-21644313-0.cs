    public async Task DownloadFileAsync(string url, IProgress<double> progress, CancellationToken token)
    {
        var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, token);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(string.Format("The request returned with HTTP status code {0}", response.StatusCode));
        }
        var total = response.Content.Headers.ContentLength.HasValue ? response.Content.Headers.ContentLength.Value : -1L;
        var canReportProgress = total != -1 && progress != null;
        using (var stream = await response.Content.ReadAsStreamAsync())
        {
            var totalRead = 0L;
            var buffer = new byte[4096];
            var isMoreToRead = true;
            do
            {
                token.ThrowIfCancellationRequested();
                var read = await stream.ReadAsync(buffer, 0, buffer.Length, token);
                if (read == 0)
                {
                    isMoreToRead = false;
                }
                else
                {
                    var data = new byte[read];
                    buffer.ToList().CopyTo(0, data, 0, read);
                    // TODO: put here the code to write the file to disk
                    totalRead += read;
                    if (canReportProgress)
                    {
                        progress.Report((totalRead * 1d) / (total * 1d) * 100);
                    }
                }
            } while (isMoreToRead);
        }
    }
