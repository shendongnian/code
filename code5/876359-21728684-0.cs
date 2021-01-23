     public ActionResult GetImageUser(Int64 id_User)
        {
            try
            {
                return File(db.DUser_Image.Find(id_User).file_Data, "image/jpeg", "userimage");
            }
            catch (Exception) 
            {
                return Content("0|Image not found!");
            }
        }
        public ActionResult UploadImageUser(Int64 id_User) 
        {
            
             ImageConverter converter = new ImageConverter();
            Image img = System.Drawing.Image.FromStream(Request.InputStream);
            try
            {
                var digibeatsUser_Image = db.DUser_Image.Find(id_User);
                dUser_Image.file_Data = (byte[])converter.ConvertTo(img, typeof(byte[]));
                var entry = db.Entry(dUser_Image);
                entry.Property(e => e.file_Data).IsModified = true;
                db.SaveChanges();
                return Content("1");
            }
            catch (Exception)
            {
                DUser_Image dUser_Image = new DUser_Image();
                try
                {
                dUser_Image.id_User_Image = id_User;
                dUser_Image.file_Data = (byte[])converter.ConvertTo(img, typeof(byte[]));
                db.DUser_Image.Add(dUser_Image);
                db.SaveChanges();
                return Content("1");
                }
                catch (Exception) 
                {
                    return Content("0");
                }
            }
        }
