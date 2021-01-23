    public ActionResult FileUpload(HttpPostedFileBase file, tbl_Image model)
    {
            using(ImageEntities db = new ImageEntities()){
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/images/profile"), pic);
                file.SaveAs(path);
                tbl_Image img=new tbl_Image();
                img.imagepath=path;
                db.tbl_Images.Add(img);
                db.SaveChanges();
            }
            return View("FileUploaded", db.tbl_Image.ToList());
            }
    }
