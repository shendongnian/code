    foreach(string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        var orgDirectory = new DirectoryInfo(Server.MapPath("~/assets/uploads"));
                        string pathString = System.IO.Path.Combine(orgDirectory.ToString(),"events");
                        var fileName1 = Path.GetFileName(file.FileName);
                        bool isExists = System.IO.Directory.Exists(pathString);
                        if(!isExists)
                        {
                            System.IO.Directory.CreateDirectory(pathString);
                        }
                        var path = string.Format("{0}\\{1}", pathString, file.FileName); //pathString + file.FileName;
                        
                        file.SaveAs(path);
                        
                    }
                }
