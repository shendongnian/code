        [Authorize(Roles = "Approved")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(UploadModel m)
        {
            byte[] uploadedFile = null;
            Byte123 xxx = new Byte123();
            if (m.File != null && !string.IsNullOrEmpty(m.Title))
            {
                //var fileName = System.IO.Path.GetFileName(m.File.FileName);
                //string c = m.File.FileName.Substring(m.File.FileName.LastIndexOf("."));
               // m.Title = m.Title.Replace(c, "");
                uploadedFile = new byte[m.File.InputStream.Length]; //you get the image as byte here but you can also save it to file.
