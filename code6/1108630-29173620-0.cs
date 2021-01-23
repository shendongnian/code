    private static readonly string HOCKEYUPLOADURL = @"https://rink.hockeyapp.net/api/2/apps/{0}/crashes/";
         private static async Task SendDataAsync(String log, String userID, String contact, String description) {
                string rawData = "";
                rawData += "raw=" + Uri.EscapeDataString(log);
                if (userID != null) {
                    rawData += "&userID=" + Uri.EscapeDataString(userID);
                }
                if (contact != null) {
                    rawData += "&contact=" + Uri.EscapeDataString(contact);
                }
                if (description != null) {
                    rawData += "&description=" + Uri.EscapeDataString(description);
                }
                WebRequest request = WebRequest.Create(new Uri(String.Format(HOCKEYUPLOADURL, HOCKEYAPPID)));
        
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                using (Stream stream = await request.GetRequestStreamAsync()) {
                    byte[] byteArray = Encoding.UTF8.GetBytes(rawData);
                    stream.Write(byteArray, 0, rawData.Length);
                    stream.Flush();
                }
        
                try {
                    using (WebResponse response = await request.GetResponseAsync()) { }
                }
                catch (WebException e) {
                    WriteLocalLog(e, "HockeyApp SendDataAsync failed");
        
                }
        
            }
