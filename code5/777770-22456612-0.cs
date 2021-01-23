            [HttpPost]
            public ActionResult UploadFile(YourModel model1)
            {
            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength > 0)
                {
                    string folderPath = Server.MapPath("~/ServerFolderPath");
                    Directory.CreateDirectory(folderPath);
                    string savedFileName = Server.MapPath("~/ServerFolderPath/" + hpf.FileName);
                    hpf.SaveAs(savedFileName);
                    return Content("File Uploaded Successfully");
                }
                else
                {
                    return Content("Invalid File");
                }
                model1.Image = "~/ServerFolderPath/" + hpf.FileName;
            }
            //Refactor the code as per your need
            return View();
        }
