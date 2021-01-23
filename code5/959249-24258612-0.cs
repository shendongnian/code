    public static byte[] SavePhoto(string fileUploadId)
    {
      System.Web.UI.Page page = (System.Web.UI.Page)HttpContext.Current.Handler;
      if (page != null)
      {
        FileUpload uploadCtrl = (FileUpload)page.FindControl(fileUploadId);
        ...
      }
    }
