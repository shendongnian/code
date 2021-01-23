    static void ZipArchiveTest()
            {
                storageAccount = CloudStorageAccount.DevelopmentStorageAccount;
                CloudBlobContainer container = storageAccount.CreateCloudBlobClient().GetContainerReference("temp");
                container.CreateIfNotExists();
                var zipFile = @"D:\node\test2.zip";
                using (FileStream fs = new FileStream(zipFile, FileMode.Open))
                {
                    using (ZipArchive archive = new ZipArchive(fs))
                    {
                        var entries = archive.Entries;
                        foreach (var entry in entries)
                        {
                            CloudBlockBlob blob = container.GetBlockBlobReference(entry.FullName);
                            using (var stream = entry.Open())
                            {
                                blob.UploadFromStream(stream);
                            }
                        }
                    }
                }
            }
