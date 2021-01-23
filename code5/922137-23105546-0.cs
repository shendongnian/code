        public List<string> ListFilesIn(string folder)
        {
            //I get my values from Orchard CMS but as long as your credentials are correct and can access the bucket this should work a dream.
            var settings = new {S3ServiceUrl = "", S3SecretKey="", S3KeyId = "", S3BucketName = ""}
            var amazonS3Config = new AmazonS3Config
            {
                ServiceURL = string.Format("https://{0}", settings.S3ServiceUrl)
            };
            folder += folder.Substring(folder.Length - 1, 1) == "/" ? "" : "/";
            using (var amazonS3Client = new AmazonS3Client(settings.S3KeyId,
             settings.S3SecretKey,
             amazonS3Config))
            {
                var response = amazonS3Client.ListObjects(new ListObjectsRequest
                {
                    BucketName = settings.S3BucketName,
                    Prefix = folder
                });
                if (response.S3Objects.Count() > 0)
                {
                    return response.S3Objects.Select(s => s.Key).Where(w=>w != folder).ToList();
                }
                else
                {
                    return new List<string>();
                }
            }
        }
