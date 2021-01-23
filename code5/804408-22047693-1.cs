        public void GetImageById(int id)
        {
            if (id == -1)
                return;
            byte[] imageArray = db.Categories.Find(id).Picture;
            using (MemoryStream stream = new MemoryStream())
            {
                // Northwind Category images were designed for MS Access, which expects a 78 byte OLE header
                int offset = 78;
                stream.Write(imageArray, offset, imageArray.Length - offset);
                Image image = Image.FromStream(stream);
                image.Save(HttpContext.Response.OutputStream, ImageFormat.Jpeg);
            }
        }
