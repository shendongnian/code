        public static async Task<List<string>> ListBlobNamesAsync(CloudBlobContainer container)
        {
            var blobs = await ListBlobsAsync(container);
            return blobs.Cast<CloudBlockBlob>().Select(b => b.Name).ToList();
            //Alternate version
            //return blobs.Select(b => b.Uri.ToString()).Select(s => s.Substring(s.LastIndexOf('/') + 1)).ToList();
        }
        public static async Task<List<IListBlobItem>> ListBlobsAsync(CloudBlobContainer container)
        {
            BlobContinuationToken continuationToken = null; //start at the beginning
            var results = new List<IListBlobItem>();
            do
            {
                var response = await container.ListBlobsSegmentedAsync(continuationToken);
                continuationToken = response.ContinuationToken;
                results.AddRange(response.Results);
            }
            while (continuationToken != null); //when this is null again, we've reached the end
            return results;
        }
