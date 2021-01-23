     var myfile = new FileInfo(filePath);
                if (myfile.Exists)
                {
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + myfile.Name);
                    HttpContext.Current.Response.AddHeader("Content-Length", myfile.Length.ToString());
                    HttpContext.Current.Response.ContentType = "text/xml";
                    HttpContext.Current.Response.TransmitFile(myfile.FullName);
                    HttpContext.Current.Response.End();                
                }
