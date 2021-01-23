        [AcceptVerbs(HttpVerbs.Post)]
        public string GetFile(string[] strings)
        {
            Guid token = Guid.NewGuid();
            InMemoryInstances instance = InMemoryInstances.Instance;
            instance.addToken(token.ToString());
            instance.addFiles(token.ToString(), strings);
            HttpCookie cookie = new HttpCookie("CookieToken");
            cookie.Value = token.ToString();
            this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
            return token.ToString();
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetFile()
        {
            InMemoryInstances instance = InMemoryInstances.Instance;
            
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("CookieToken"))
            {
                HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["CookieToken"];
                
                if (instance.checkToken(cookie.Value)) 
                {                                
                    cookie.Expires = DateTime.Now.AddDays(-1);
                
                    this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                    MemoryStream ms = new MemoryStream();
                    string[] filenames = instance.getFiles(cookie.Value);
                    using (ZipArchive zs = new ZipArchive(ms,ZipArchiveMode.Create, true))
                    {
                        for (int i=0;i < filenames.Length; i++)
                            zs.CreateEntryFromFile(filenames[i], Path.GetFileName(filenames[i]));                        
                    }
                                        
                    FileContentResult resultContent = new FileContentResult(ms.ToArray(),"application/zip");
                    instance.removeFiles(cookie.Value);
                    resultContent.FileDownloadName = "ARandomlyGeneratedFileNameHere.zip";
                    return resultContent;
                } else 
                {
                    return View("Index");
                }
            }            
            else
            {
                return View("Index");
            }
            
        }
