      foreach (IListBlobItem item in container.ListBlobs(null, true))
            {
                if (item.GetType() == typeof(CloudBlockBlob))
                {
                    video = new VideoBlob();
                    blob = container.GetBlockBlobReference(getBlobName(item.Uri.ToString()));
                    blob.FetchAttributes();
                    video.uri = item.Uri.ToString();
                    video.title = blob.Metadata["title"];
                    video.description = blob.Metadata["description"];
                 }
            }
     private String getBlobName(String link)
            {
                 //convert string to URI
                 Uri uri = new Uri(link);
                 //parse URI to get just the file name
                 return System.IO.Path.GetFileName(uri.LocalPath);  
            }
