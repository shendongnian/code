    string image = "example.com/image.jpg";
    var webClient = new WebClient();
    byte[] imageBytes = webClient.DownloadData(image);
    MemoryStream ms = new MemoryStream(imageBytes);
    LinkedResource resource = new LinkedResource(ms, MediaTypeNames.Image.Jpeg);
