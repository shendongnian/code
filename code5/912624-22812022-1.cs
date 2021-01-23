    [WebMethod]
    // To allow this Web Service to be called from script
    [System.Web.Script.Services.ScriptService]
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
