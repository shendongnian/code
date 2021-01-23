    public async Task<string> UploadMediaToCloud(string filePath, string objectName = null)
        {
            string bearerToken = GetOAuthToken();
            byte[] fileBytes = File.ReadAllBytes(filePath);
            objectName = objectName ?? Path.GetFileName(filePath);
            var baseUrl = new Uri(string.Format(googleCloudStorageBaseUrl + "" + bucketName + "/o?uploadType=media&name=" + objectName + ""));
            using (WebClient client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + bearerToken);
                client.Headers.Add(HttpRequestHeader.ContentType, "application/octet-stream");
                byte[] response = await Task.Run(() => client.UploadData(baseUrl, "POST", fileBytes));
                string responseInString = Encoding.UTF8.GetString(response);
                return responseInString;
            }
        }
