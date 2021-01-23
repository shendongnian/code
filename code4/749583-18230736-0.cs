    [WebMethod]
    public static string GetDownload(string someIdentifier) {
      // get the contents of your file, then...
      // do your logging, and...
      var serializer = new JavaScriptSerializer();
      return serializer.Serialize(fileByteArrayOrSuch);
    }
