    var client = new WebClient();
    client.Headers.Add("User-Agent", "Nobody");
    string response = client.DownloadString(new Uri("http://www.example.com/photos.json"));
    // --> 'Normalize' response string here, if necessary
    List<Photo> photos = JsonConvert.DeserializeObject<List<Photo>>(response);
  
    // now buid the HTML string
    var sb = new StringBuilder();
    foreach(photo in photos)
    {
        sb.Append(photo.ToHtml());
    }
    string fullHtml = sb.ToString();
    ...
 
