    public ActionResult FileUpload(HttpPostedFileBase file, tbl_Image model)
    {
        if (file != null)
        {
            string fileName = System.IO.Path.GetFileName(file.FileName);
            string fullPath = System.IO.Path.Combine(Server.MapPath("~/images/profile"), fileName);
            file.SaveAs(fullPath);
            db.AddTotbl_Image(new tbl_Image() { imagepath = "http://sampleApp.com/images/profile/" + fileName });
            db.SaveChanges();
        }
    
        return View("FileUploaded", db.tbl_Image.ToList());
    }
