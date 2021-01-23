    public static bool memUploadFile(AmazonS3 client, MemoryStream memFile, string toPath)
    {
        try
        {
            using(Amazon.S3.Transfer.TransferUtility tranUtility =
                          new Amazon.S3.Transfer.TransferUtility(client))
            {
                tranUtility.Upload(memFile, toPath.Replace("\\", "/"), <The key under which the Amazon S3 object is stored.>);
    
                return true;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }
