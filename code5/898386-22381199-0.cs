    [HttpPost]
        public ActionResult Index(SampleModel model)
        {
            string fileName1 = "";
            HttpPostedFileBase uploads ;
            
            if (Request.Files.Count > 0)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    //uploads[i] = new HttpPostedFileBase();
                    uploads = Request.Files[i];
                    fileName1 = Path.GetFileName(uploads.FileName);
                    uploads.SaveAs(Server.MapPath(fileName1));
                }
            }
