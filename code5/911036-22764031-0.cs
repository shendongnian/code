        static void DownloadRangeExample()
        {
            var cloudStorageAccount = CloudStorageAccount.DevelopmentStorageAccount;
            var containerName = "container";
            var blobName = "myfile.zip";
            int segmentSize = 1 * 1024 * 1024;//1 MB chunk
            var blobContainer = cloudStorageAccount.CreateCloudBlobClient().GetContainerReference(containerName);
            var blob = blobContainer.GetBlockBlobReference(blobName);
            blob.FetchAttributes();
            var blobLengthRemaining = blob.Properties.Length;
            long startPosition = 0;
            string saveFileName = @"D:\myfile.zip";
            do
            {
                long blockSize = Math.Min(segmentSize, blobLengthRemaining);
                byte[] blobContents = new byte[blockSize];
                using (MemoryStream ms = new MemoryStream())
                {
                    blob.DownloadRangeToStream(ms, startPosition, blockSize);
                    ms.Position = 0;
                    ms.Read(blobContents, 0, blobContents.Length);
                    using (FileStream fs = new FileStream(saveFileName, FileMode.OpenOrCreate))
                    {
                        fs.Position = startPosition;
                        fs.Write(blobContents, 0, blobContents.Length);
                    }
                }
                startPosition += blockSize;
                blobLengthRemaining -= blockSize;
            }
            while (blobLengthRemaining > 0);
        }
