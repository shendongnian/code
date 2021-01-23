               using (var fileTransferUtility = new TransferUtility(client))
                {
                    var request = new TransferUtilityDownloadRequest();
                    request.BucketName = BucketName;
                    request.FilePath = desination;
                    request.Key = key;
                    fileTransferUtility.Download(request);
                }
