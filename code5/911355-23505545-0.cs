     public async Task AddPhotoAsync(Photo photo)
        {
            var containerName = string.Format("profilepics-{0}", photo.ProfileId).ToLowerInvariant();
            var blobStorage = _storageService.StorageAccount.CreateCloudBlobClient();
            var cloudContainer = blobStorage.GetContainerReference("profilephotos");
            
            if(cloudContainer.CreateIfNotExists())
            {
                var permissions = await cloudContainer.GetPermissionsAsync();
                permissions.PublicAccess = BlobContainerPublicAccessType.Container;
                cloudContainer.SetPermissions(permissions);
            }
            string uniqueBlobName = string.Format("profilephotos/image_{0}{1}", Guid.NewGuid().ToString(),Path.GetExtension(photo.UploadedImage.FileName));
            var blob = cloudContainer.GetBlockBlobReference(uniqueBlobName);
            blob.Properties.ContentType = photo.UploadedImage.ContentType;
            blob.UploadFromStream(photo.UploadedImage.InputStream);
            photo.Url = blob.Uri.ToString();
            await AddPhotoToDB(photo);
            
        }
