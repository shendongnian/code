    [HttpPost]
    public ActionResult CSVUpload(HttpPostedFileBase fileUpload)
    {
        try
        {
            Debug.Write(fileUpload.ContentLength);
            if (fileUpload.ContentLength < 0 || fileUpload == null)
            {
                Debug.Write("unable to detectFile");
            }
        }
        catch
        {
            Debug.Write("file error");
        }
        return View();
    }
