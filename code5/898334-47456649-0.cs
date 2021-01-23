                    if (System.IO.Directory.Exists(Server.MapPath("~/Files/")) == false)
                    {
                        System.IO.Directory.CreateDirectory(Server.MapPath("~/Files/"));
                        System.IO.Directory.Delete(Server.MapPath("~/Files/") + path);
                     }
                   
                    else
                    {
                        
                     FLUpload.SaveAs(Server.MapPath(path));
                    }
                }
              
