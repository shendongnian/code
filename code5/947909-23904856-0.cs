            CloudStorageAccount acc = new CloudStorageAccount(new StorageCredentials("<accountname>", "<accountKey>"), true);
            var client = acc.CreateCloudBlobClient();
            var container = client.GetContainerReference("<containername>");
            var blob = container.GetBlockBlobReference("<imagename.png>");
            var sasToken = blob.GetSharedAccessSignature(new SharedAccessBlobPolicy()
            {
                SharedAccessExpiryTime = DateTime.UtcNow.AddHours(1),
                Permissions = SharedAccessBlobPermissions.Read
            }, new SharedAccessBlobHeaders()
            {
                ContentDisposition = "attachment;filename=<imagename.png>",
            });
            var blobUrl = blob.Uri.AbsoluteUri + sasToken;
            Redirect(blobUrl);
