    YouTubeService youtube = new YouTubeService(new BaseClientService.Initializer() {
        ApplicationName = "{yourAppName}",
        ApiKey = "{yourApiKey}",
    });
    SearchResource.ListRequest listRequest = youtube.Search.List("snippet");
    listRequest.Q = "Loeb Pikes Peak";
    listRequest.MaxResults = 5;
    listRequest.Type = "video";
    SearchListResponse resp = listRequest.Execute();
    foreach (SearchResult result in resp.Items) {
        CommandLine.WriteLine(result.Snippet.Title);
    }
