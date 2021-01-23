     [MySite.WebUI.Infrastructure.AjaxCrawlable]
            public ActionResult Index()
            {
                string url = Request.Url.AbsolutePath;
                if (url.LastIndexOf('.') != -1)
                {
                    string extention = url.Substring(url.LastIndexOf('.') + 1).ToLower();
                    var extentionList = new string[] { "jpg", "png", "gif", "tif" };
                    if (extentionList.Contains(extention))
                    {
                        try
                        {
                            string path = System.Web.Hosting.HostingEnvironment.MapPath(Request.Url.AbsolutePath);
                            string FileName = System.IO.Path.GetFileNameWithoutExtension(path);
                            string extentionnow = System.IO.Path.GetExtension(path);
                            var _mainpath = Request.Url.AbsolutePath.Substring(0, Request.Url.AbsolutePath.LastIndexOf("/"));
                            string _mainfileName = FileName.Substring(0, (FileName.LastIndexOf('_')));
                            int _imagesize = int.Parse(FileName.Substring((FileName.LastIndexOf('_') + 1)));
                            if (_imagesize != null || _imagesize != 0)
                            {
                                var t = Resize.FindResizeImage("~" + _mainpath + "/" + _mainfileName + extentionnow, _imagesize);
                                return new RedirectResult(Request.Url.AbsolutePath);
                            }
                        }
                        catch
                        {
                            return View();
                        }
    
                    }
                }
                else
                    return View();
                return View();
            }
