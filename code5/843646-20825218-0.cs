        ImageEntities db = new ImageEntities();
        public ActionResult FileUpload(HttpPostedFileBase file, tbl_Image model)
        {
                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(
                                           Server.MapPath("~/images/profile"), pic);
                    file.SaveAs(path);
                    db.tbl_Image.Add(new tbl_Image(){imagepath=path});
                    db.SaveChanges();
                }
                
                return View("FileUploaded", db.tbl_Image.ToList());
        }
