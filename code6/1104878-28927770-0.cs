    public static string UploadVideo(HttpPostedFileBase file, dynamic ticket)
        {
            try
            {
                var apiUrl = ticket.upload_link_secure;
                using (var client = new WebClient())
                {
                    client.Headers.Add(HttpRequestHeader.Authorization, "bearer " + AccessToken);
                    client.Headers.Add("Accept", "application/vnd.vimeo.*+json;version=3.0");
                    using (var binaryReader = new BinaryReader(file.InputStream))
                    {
                       client.UploadData(apiUrl, "PUT", binaryReader.ReadBytes(file.ContentLength));
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.LogEvent("Error uploading video: ", ex.Message, ex.ToString(),
                    EventTypes.Error, false, "");
            }
            return "Failed";
        }
