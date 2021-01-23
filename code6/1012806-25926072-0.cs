    LiveConnectClient connectClient = new LiveConnectClient(this.Session);
    Uri uri = new Uri("https://apis.live.net/v5.0/" + FolderID + "/files/" + Filename + "?access_token=" + connectClient.Session.AccessToken, UriKind.Absolute);
    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, uri);
    request.Content = new HttpStreamContent(await InputFile.OpenAsync(FileAccessMode.Read));
    HttpResponseMessage response = await httpClient.SendRequestAsync(request, HttpCompletionOption.ResponseHeadersRead);
    
    if (response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.Ok)
    {...}
