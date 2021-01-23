        public ActionResult Index(int id, int? height, int? width)
        {
            int h = (height ?? 325);
            int w = (width ?? 325);
            Staff staff = db.StaffList.Find(id);
            if (staff == null)
            {
                return new HttpNotFoundResult();
            }
            if (staff.Photo != null)
            {
                Size size = new Size(w, h);
                byte[] rawImg;
                using (MemoryStream inStream = new MemoryStream(staff.Photo))
                {
                    using (MemoryStream outStream = new MemoryStream())
                    {
                        using (ImageFactory imageFactory = new ImageFactory())
                        {
                            imageFactory.Load(inStream)
                                .Constrain(size)
                                .Format(format)
                                .Save(outStream);
                        }
                        rawImg = outStream.ToArray();
                    }
                }
                return new FileContentResult(rawImg, "image/jpeg");
            }
            else
            {
                return null;
            }
        }
