    string _fileName = string.Empty;
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        try
        {
            if (context.Request.Files.Count > 0)
            {
                HttpFileCollection files = context.Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];
                    if (file.ContentLength / 1024 < 1024 * 1) //1024*1 = 1 MB
                    {
                        _fileName = file.FileName;
                        string fname =
                            context.Server.MapPath("~/tools/DragAndDropFileUpload/uploads/" +
                                                   MyRandomChar.StringIntNumber(20) + Path.GetExtension(_fileName));
                        file.SaveAs(fname);
                    }
                    else
                        throw new Exception("Maximum file size exceeded.");
                }
                context.Response.Write("Uploaded Successfully!");
            }
        }
        catch (Exception ex)
        {
            context.Response.Write(ex.Message);
        }
    }
