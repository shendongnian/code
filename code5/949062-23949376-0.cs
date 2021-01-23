        static void GetOldBlobs()
        {
            CloudStorageAccount acc = new CloudStorageAccount(new StorageCredentials("account name", "account key"), false);
            var client = acc.CreateCloudBlobClient();
            var container = client.GetContainerReference("container name");
            var blobs = container.ListBlobs("", true).OfType<CloudBlockBlob>().Where(b => (DateTime.UtcNow.AddDays(-7) > b.Properties.LastModified.Value.DateTime)).ToList();
        }
