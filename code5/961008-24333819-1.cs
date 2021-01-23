        public static string GetDownloadLink(string fileName)
        {
            CloudBlobContainer container = GetBlobContainer();
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
            //Create an ad-hoc Shared Access Policy with read permissions which will expire in 12 hours
            SharedAccessBlobPolicy policy = new SharedAccessBlobPolicy()
            {
                Permissions = SharedAccessBlobPermissions.Read,
                SharedAccessExpiryTime = DateTime.UtcNow.AddHours(12),
            };
            //Set content-disposition header for force download
            SharedAccessBlobHeaders headers = new SharedAccessBlobHeaders()
            {
                ContentDisposition = string.Format("attachment;filename=\"{0}\"", fileName),
            };
            var sasToken = blockBlob.GetSharedAccessSignature(policy, headers);
            return blockBlob.Uri.AbsoluteUri + sasToken;
        }
        public ActionResult Download(string fileName)
        {
            var sasUrl = GetDownloadLink(fileName);
            //Redirect to SAS URL ... file will now be downloaded directly from blob storage.
            Redirect(sasUrl);
        }
