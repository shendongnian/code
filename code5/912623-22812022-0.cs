    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]    
    public List<string> getlastimages()
    {
      DBservices DBS = new DBservices();
      List<string> ImageUrls = new List<string>();
      try
      {
       DBS.getLastImages();
       ImageUrls = DBS.ImgUrlList;
      }
      catch(Exception ex)
      {
        throw ex;
      }
      return ImageUrls;
    }
