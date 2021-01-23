    public ActionResult Picture()
            {
                Byte[] Picture;
                
                var filePath = "D:\FunRanger2\FunRangerPhotos\Desert.png";
                if (System.IO.File.Exists(filePath))
                {
                    Picture = System.IO.File.ReadAllBytes(filePath);
                }
                
                return File(Picture, "image/png");
            }
