    private static GetData(string urlParameter) {
        string response = string.Empty; // This will be the data that is returned.
        string url  = "http://skype.api.com/someCall?param={0}"; // The API URL you want to call.
        using (var client = new WebClient()) {
            // This will get the data from your API call.
            response = client.DownloadString(string.Format(url, urlParameter));
        }
        JObject obj = null; // This is the Newtonsoft object.
        try {
            obj = JObject.Parse(response);
            // Continue on processing the data as need be.
        }
        catch {
            // Always be prepared for exceptions
        }
