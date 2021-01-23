    public class AzureBlobStorageService : IBlobStorageService
    {
        private readonly AzureBlobConnectionConfigurations _azureBlobConnectionOptions;
        private readonly CloudStorageAccount _storageAccount;
        private readonly CloudBlobClient _blobClient;
        public AzureBlobStorageService(IOptions<AzureBlobConnectionConfigurations> azureBlobConnectionAccessor)
        {
            _azureBlobConnectionOptions = azureBlobConnectionAccessor.Value;
            _storageAccount = CloudStorageAccount.Parse(_azureBlobConnectionOptions.StorageConnectionString);
            _blobClient = _storageAccount.CreateCloudBlobClient();
        }
        public async Task<Uri> UploadAsync(string containerName, string blobName, IFormFile image)
        {
            ...
        }
        public async Task<Uri> UploadAsync(string containerName, string blobName, byte[] imageBytes)
        {
            ...
        }
        public async Task<byte[]> GetBlobByUrlAsync(string url, bool deleteAfterFetch = false)
        {
            // This works
            var blockBlob = new CloudBlockBlob(new Uri(url), _storageAccount.Credentials);
            // Even this will fail
            //var blockBlob = new CloudBlockBlob(new Uri(url));
            await blockBlob.FetchAttributesAsync();
            byte[] arr = new byte[blockBlob.Properties.Length];
            await blockBlob.DownloadToByteArrayAsync(arr, 0);
            if (deleteAfterFetch)
            {
                await blockBlob.DeleteIfExistsAsync();
            }
            return arr;
        }
        private async Task<CloudBlobContainer> CreateContainerIfNotExistAsync(string containerName)
        {
            var container = _blobClient.GetContainerReference(containerName);
            if (!await container.ExistsAsync())
            {
                await container.CreateAsync();
                await container.SetPermissionsAsync(new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });
            }
            return container;
        }
    }
