    try
    {
      var imageUrl = SPContext.Current.Web.Url + "/_layouts/CGCDocumentHistoryView/Images/eskom.png";
      byte[] imageData;
    
      using (var webclient = new WebClient())
      {
         imageData = webclient.DownloadData(imageUrl);
      }
    }
    catch(Exception ex)
    {
       // Check the exception
    }
