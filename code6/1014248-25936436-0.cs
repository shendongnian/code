        [HttpPost]
        public ActionResult Upload()
        {
            foreach (string inputTagName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[inputTagName];
                if (file.ContentLength > 0)
                {
                    string filePath = Path.Combine(HttpContext.Server.MapPath("../Images")
                            , Path.GetFileName(file.FileName));
                    file.SaveAs(filePath);
                }
            }
            // Below line is missing
            return View();
         }
