    private MediaItem AddFile(string relativeUrl, string sitecorePath, string mediaItemName)
    {
        var extension = Path.GetExtension(relativeUrl);
    
        var localFilename = @"c:\temp\" + mediaItemName + extension;
        using (var client = new WebClient())
        {
            client.DownloadFile("http://yourdomain.com" + relativeUrl, localFilename);
        }
    
        // Create the options
        var options = new MediaCreatorOptions
            {
                FileBased = false,
                IncludeExtensionInItemName = false,
                KeepExisting = false,
                Versioned = false,
                Destination = sitecorePath + "/" + mediaItemName,
                Database = Factory.GetDatabase("master")
            };
    
        // Now create the file
        var creator = new MediaCreator();
        var mediaItem = creator.CreateFromFile(localFilename, options);
        return mediaItem;
    }
