        [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
        [Authorize]
        public ActionResult DownloadExportedFile(string filename = null)
        {
            if (!String.IsNullOrEmpty(filename))
            {
                var tempDirPath = System.IO.Path.GetTempPath();
                if (System.IO.File.Exists(tempDirPath + filename))
                {
                    var bytes = System.IO.File.ReadAllBytes(tempDirPath + filename);
                    System.IO.File.Delete(tempDirPath + filename);
                    var cd = new System.Net.Mime.ContentDisposition
                    {
                        FileName = Path.GetFileName("BookingForm.csv"),
                        // always prompt the user for downloading, set to true if you want 
                        // the browser to try to show the file inline
                        Inline = false
                    };
                    //Response.AppendHeader("Content-Disposition", cd.ToString());
                    return File(bytes, "text/csv", "BookingForm.csv");
                }
            }
            return new HttpStatusCodeResult(404, "File not found!");
        }
