    var filepath = mediaFile.FilesystemLocation;
    if (!File.Exists(filepath))
    {
        return new HttpResponseMessage(404);
    }
    else{
       var result = new HttpResponseMessage(HttpStatusCode.OK);
       //just in case file has disappeared / or is locked for open, 
       //wrap in try/catch
       try
       {
           result.Content = new StreamContent(
              new FileStream(filepath, FileMode.Open));
       }
       catch
       {
           return new HttpResponseMessage(500);           
       }
        return result;
    }
