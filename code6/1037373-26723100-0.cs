    [HttpPost]
        public virtual ActionResult UploadFile()
        {
            //var myFile = System.Web.HttpContext.Current.Request.Files["UploadedFiles"];
            //
            bool isUploaded = false;
            string message = "File upload failed";
            for (int i = 0; i < Request.Files.Count; i++ )
            {
                var myFile = Request.Files[i];
                if (myFile != null && myFile.ContentLength != 0)
                {
                    string pathForSaving = Server.MapPath("~/Uploads");
                    if (this.CreateFolderIfNeeded(pathForSaving))
                    {
                        try
                        {
                            myFile.SaveAs(Path.Combine(pathForSaving, myFile.FileName));
                            isUploaded = true;
                            message = "File uploaded successfully!";
                        }
                        catch (Exception ex)
                        {
                            message = string.Format("File upload failed: {0}", ex.Message);
                        }
                    }
                }
            }
                
            return Json(new { isUploaded = isUploaded, message = message }, "text/html");
        }
        #endregion
        #region Private Methods
        /// <summary>
        /// Creates the folder if needed.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        private bool CreateFolderIfNeeded(string path)
        {
            bool result = true;
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception)
                {
                    /*TODO: You must process this exception.*/
                    result = false;
                }
            }
            return result;
        }
        #endregion
    }
