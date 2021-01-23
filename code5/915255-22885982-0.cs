    [HttpPost]
    public string UploadImg(HttpPostedFileBase file) {
       //Save the file :
       if (file != null && file.ContentLength > 0) {
          file.SaveAs(path);
       }
    }
