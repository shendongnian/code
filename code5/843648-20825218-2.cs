        ImageEntities db = new ImageEntities();
        public ActionResult FileUpload(HttpPostedFileBase file, tbl_Image model)
        {
                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(
                                           Server.MapPath("~/images/profile"), pic);
                    file.SaveAs(path);
                    db.tbl_Image.AddObject(new tbl_Image(){imagepath="~/images/profile/"+pic});
                    db.SaveChanges();
                }
                
                return View("FileUploaded", db.tbl_Image.ToList());
        }
