            // Setup
            IContentService cs = ApplicationContext.Current.Services.ContentService;
            var mediaService = ApplicationContext.Current.Services.MediaService;
            int mediaRootId = 1111; // Replace with the id of your media parent folder
            // Replace the image looping logic with the following:
            // MultiMediaPicker stores it's values as a commma separated string of ids.
            string imageIds = string.Empty;
            foreach (var image in product.Images)
            {
                var fileName = image.FileName; // Assumes no path information, just the file name
                var ext = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();
                if (!UmbracoConfig.For.UmbracoSettings().Content.DisallowedUploadFiles.Contains(ext))
                {
                    var mediaType = Constants.Conventions.MediaTypes.File;
                    if (UmbracoConfig.For.UmbracoSettings().Content.ImageFileTypes.Contains(ext))
                        mediaType = Constants.Conventions.MediaTypes.Image;
                    var f = mediaService.CreateMedia(fileName, mediaRootId, mediaType);
                    // Assumes the image._Image is a Stream - you may have to do some extra work here...
                    f.SetValue(Constants.Conventions.Media.File, fileName, (Stream)image._Image); // Real magic happens here.
                    mediaService.Save(f);
                    imageIds += (imageIds.Length > 0 ? "," : "") + f.Id;
                }
            }
            // Get the relevant property on the new item and save the image list to it.
            var imagesProp = item.Properties.Where(p => p.Alias == "productImages").FirstOrDefault();
            imagesProp.Value = imageIds;
