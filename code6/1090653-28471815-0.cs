    var block = new ActionBlock<Content>(
    async content => 
    {
        var tasks = interactionProviders.
            Where(provider => provider.IsServiceSupported(content.ServiceType)).
            Select(provider => provider.UpdateThumbnail(content));
        await Task.WhenAll(tasks);
        
        if (content.ThumbnailLink != null && !content.ThumbnailLink.Equals(
            content.FileIconLink, 
            StringComparison.CurrentCultureIgnoreCase))
        {
            await DownloadAndUpdateThumbnailCache(content);
        }
    }, new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 5});
