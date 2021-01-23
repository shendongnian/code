     [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult ShowExcelFile()
        {
            // For getting the file that is Uploadeded.
            HttpPostedFileBase fileUpload = Request.Files["Files"];
            byte[] data;
            using (Stream inputStream = fileUpload.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                     data = memoryStream.ToArray();
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
               
            }
           
            return  Json(new { }, JsonRequestBehavior.AllowGet);
        }
    
