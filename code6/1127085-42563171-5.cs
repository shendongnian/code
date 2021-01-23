    public static TfsProject GetTfsProjectGuid(string projectName, string collectionName)
    {
        var tfsInstance = ConfigurationManager.AppSettings["TFSInstance"];
        using (var client = new WebClient())
        {
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            client.UseDefaultCredentials = true;
            var tfsUri = new Uri(tfsInstance + collectionName + "/_apis/projects/" + projectName + "?api-version=1.0");
            var response = client.DownloadString(tfsUri);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Deserialize<TfsProject>(response.ToString());
        }
    }
