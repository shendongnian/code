    public async static Task<string> DownloadFileAsync(this LiveConnectClient client, string directory, string fileName)
        {
            string skyDriveFolder = await OneDriveHelper.CreateOrGetDirectoryAsync(client, directory, "me/skydrive");
            var result = await client.DownloadAsync(skyDriveFolder);
            var operation = await client.GetAsync(skyDriveFolder + "/files");
            var items = operation.Result["data"] as List<object>;
            string id = string.Empty;
            // Search for the file - add handling here if File Not Found
            foreach (object item in items)
            {
                IDictionary<string, object> file = item as IDictionary<string, object>;
                if (file["name"].ToString() == fileName)
                {
                    id = file["id"].ToString();
                    break;
                }
            }
            var downloadResult= await client.DownloadAsync(string.Format("{0}/content", id));
            var reader = new StreamReader(downloadResult.Stream);
            string text = await reader.ReadToEndAsync();
            return text;
        }
