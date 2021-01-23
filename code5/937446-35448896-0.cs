    public ActionResult AddImageUpload(IEnumerable<HttpPostedFileBase> files,FormCollection fc )
            {
                ImageUpload IU = new ImageUpload();
                IU.MaterialId = Convert.ToInt32((fc["MaterialId"]).Replace("number:",""));
                IU.CategoryId = Convert.ToInt32((fc["CategoryId"]).Replace("number:", "")); 
                string tr = fc["hdnSub"].ToString();
                string result = null;
                string Message, fileName, actualFileName;
                Message = fileName = actualFileName = string.Empty;
                bool flag = false;
                //HttpPostedFileBase f= IU.ImageP;
                string[] SubAssemblyId = (tr.Split(','));
                int i = 0;
                string databaseid = null;
                for (int j=0 ; j<files.Count(); j++)
                {
    
                    var fileContent = Request.Files[j];
                    if (fileContent.FileName != "")
                    {
                        databaseid = SubAssemblyId[i];
                        string fn = DateTime.Now.ToShortDateString().Replace("/", "") + DateTime.Now.TimeOfDay.Hours + DateTime.Now.TimeOfDay.Minutes + DateTime.Now.TimeOfDay.Seconds + DateTime.Now.TimeOfDay.Milliseconds + Path.GetExtension(fileContent.FileName);
                        fileName = fn;
                        try
                        {
                            if (fileContent != null && fileContent.ContentLength > 0)
                            {
                                var inputStream = fileContent.InputStream;
                                var path = Path.Combine(Server.MapPath("/Images/Product/"), fn);
                                using (var fileStream = System.IO.File.Create(path))
                                {
                                    inputStream.CopyTo(fileStream);
                                }
    
                            }
     }
                        catch (Exception)
                        {
    
                        }
    
                    }
                    i++;
    
                }
    return RedirectToAction("ImageUpload");
            }
