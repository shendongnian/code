     public static CloudBlockBlob BlobPropertySetting(CloudBlobClient cloudBlobClientReferenceName, string blobContentName)
        {
            CloudBlockBlob blob = cloudBlobClientReferenceName.GetBlockBlobReference("upload/" + blobContentName);
            return blob;
        }
