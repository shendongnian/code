        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase logo)
        {
            SetupViewState();
            SaveLogos(logo);
            return View();
        }
        private void SaveLogos(HttpPostedFileBase logo)
        {
            if (logo != null && logo.ContentLength > 0)
            {
                var ext = Path.GetExtension(logo.FileName);
                var path = Server.MapPath("~/Content/Images");
                var full = Path.Combine(path, "logo.png");
                path = Path.Combine(path, "Mobile");
                var mobile = Path.Combine(path, "logo.png");
                var tmp = Path.GetTempFileName() + "." + ext;
                try
                {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    if (System.IO.File.Exists(full))
                    {
                        System.IO.File.Move(full, full.Replace(".png", DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".png"));
                    }
                    if (System.IO.File.Exists(mobile))
                    {
                        System.IO.File.Move(mobile, mobile.Replace(".png", DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".png"));
                    }
                    // convert to png
                    logo.SaveAs(tmp);
                    var job = new ImageResizer.ImageJob(tmp, full,
                        new ImageResizer.ResizeSettings("width=460;height=102;format=png;mode=pad"));
                    job.Build();
                    // create mobile image
                    job = new ImageResizer.ImageJob(tmp, mobile,
                        new ImageResizer.ResizeSettings("width=190;height=44;format=png;mode=pad"));
                    job.Build();
                }
                catch (Exception e)
                {
                    Logging.LogError(e, ControllerContext);
                }
                finally
                {
                    System.IO.File.Delete(tmp);
                }
            }
        }
