    [HttpPost]
        public void UploadFile()
        {
            var context = HttpContext.Current;
            if (context.Request.Files.Count > 0)
            {
                HttpFileCollection SelectedFiles = context.Request.Files;
                for (int i = 0; i < SelectedFiles.Count; i++)
                {
                    HttpPostedFile PostedFile = SelectedFiles[i];
                    string FileName = context.Server.MapPath("~/Content/uploads/" + PostedFile.FileName);
                    PostedFile.SaveAs(FileName);
                }
            }
            else
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("Please Select Files");
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write("Files Uploaded Successfully!!");
        }
