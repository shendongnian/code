    var filepath = mediaFile.FilesystemLocation;
    if (!File.Exists(filepath))
    {
        return new HttpResponseMessage(404);
    }
    else{
       var result = new HttpResponseMessage(HttpStatusCode.OK);
       result.Content = new StreamContent(
           new FileStream(filepath, FileMode.Open));
        return result;
    }
