    public const string CachedImagesFolderFullPath = "ms-appdata:///local/cache/";
    public const string CachedImagesFolderEndFolderPath = "cache";
    public const string OfflinePhotoImgPath = "ms-appx:///Assets/OfflinePhoto.png";
    public const int MaximumColumnWidth = 700;
    public static async Task<string> GetLocalImageAsync(string internetUri)
    {
        if (string.IsNullOrEmpty(internetUri))
        {
            return null;
        }
        // Show default image if local folder does not exist
        var localFolder = ApplicationData.Current.LocalFolder;
        if (localFolder == null)
        {
            return OfflinePhotoImgPath;
        }
        // Default to offline photo
        string src = OfflinePhotoImgPath;
        try
        {
            using (var response = await HttpWebRequest.CreateHttp(internetUri)
                                                      .GetResponseAsync())
            {
                using (var stream = response.GetResponseStream())
                {
                    // New random filename (e.g. x53fjtje.jpg)
                    string fileName = string.Format("{0}.jpg",
                        Path.GetFileNameWithoutExtension(Path.GetRandomFileName()));
                    var imageFolder = await localFolder.CreateFolderAsync(
                        CachedImagesFolderEndFolderPath, 
                        CreationCollisionOption.OpenIfExists);
                    var file = await imageFolder.CreateFileAsync(fileName, 
                        CreationCollisionOption.ReplaceExisting);
                    // Copy bytes from stream to local file 
                    // without changing any file information
                    using (var filestream = await file.OpenStreamForWriteAsync())
                    {
                        await stream.CopyToAsync(filestream);
                        // Send back the local path to the image 
                        // (including 'ms-appdata:///local/cache/')
                        return string.Format(CachedImagesFolderFullPath + "{0}", 
                             fileName);
                    }
                }
            }
        }
        catch (Exception)
        {
            // Is implicitly handled with the setting 
            // of the initilized value of src
        }
        // If not succesfull, return the default offline image
        return src;
    }
    public static async Task<string> ResizeAndCompressLocalImage(string imgSrc)
    {
        // Remove 'ms-appdata:///local/cache/' from the path ... 
        string sourcepathShort = imgSrc.Replace(
                                     CachedImagesFolderFullPath,
                                     string.Empty);
        // Get the cached images folder
        var folder = await ApplicationData.Current
                              .LocalFolder
                              .GetFolderAsync(
                                   CachedImagesFolderEndFolderPath);
        // Get a new random name (e.g. '555jkdhr5.jpg')
        var targetPath = string.Format("{0}.jpg",
                              Path.GetFileNameWithoutExtension(
                                  Path.GetRandomFileName()));
        // Retrieve source and create target file
        var sourceFile = await folder.GetFileAsync(sourcepathShort);
        var targetFile = await folder.CreateFileAsync(targetPath);
        using (var sourceFileStream = await sourceFile.OpenAsync(
                       Windows.Storage.FileAccessMode.Read))
        {
            using (var destFileStream = await targetFile.OpenAsync(
                       FileAccessMode.ReadWrite))
            {
                // Prepare decoding of the source image
                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(
                                                  sourceFileStream);
                // Find out if image needs resizing
                double proportionWidth = (double)decoder.PixelWidth /
                                         LayoutDimensions.MaximumColumnWidth;
                double proportionImage = decoder.PixelHeight / 
                                         (double)decoder.PixelWidth;
                // Get the new sizes of the image whether it is the same or should be resized
                var newWidth = proportionWidth > 1 ? 
                               (uint)(MaximumColumnWidth) : 
                               decoder.PixelWidth;
                var newHeight = proportionWidth > 1 ? 
                                (uint)(MaximumColumnWidth * proportionImage) : 
                                decoder.PixelHeight;
                // Prepare set of properties for the bitmap
                BitmapPropertySet propertySet = new BitmapPropertySet();
                    
                // Set ImageQuality
                BitmapTypedValue qualityValue = new BitmapTypedValue(0.75, 
                                                        PropertyType.Single);
                propertySet.Add("ImageQuality", qualityValue);
                //BitmapEncoder enc = await BitmapEncoder.CreateForTranscodingAsync(
                                                destFileStream, decoder);
                BitmapEncoder enc = await BitmapEncoder.CreateAsync(
                                              BitmapEncoder.JpegEncoderId, 
                                              destFileStream, propertySet);
                // Set the new dimensions
                enc.BitmapTransform.ScaledHeight = newHeight;
                enc.BitmapTransform.ScaledWidth = newWidth;
                // Get image data from the source image
                PixelDataProvider pixelData = await decoder.GetPixelDataAsync();
                // Copy in all pixel data from source to target
                enc.SetPixelData(
                    decoder.BitmapPixelFormat,
                    decoder.BitmapAlphaMode,
                    decoder.PixelWidth, 
                    decoder.PixelHeight, 
                    decoder.DpiX, 
                    decoder.DpiY, 
                    pixelData.DetachPixelData()
                    );
                // Make the encoder process the image
                await enc.FlushAsync();
                // Write everything to the filestream 
                await destFileStream.FlushAsync();
            }
        }
        try
        {
            // Delete the source file
            await sourceFile.DeleteAsync();
        }
        catch(Exception)
        {
        }
        // Return the new path 
        // including "ms-appdata:///local/cache/"
        return string.Format(CachedImagesFolderFullPath + "{0}", 
             targetPath);
    }
