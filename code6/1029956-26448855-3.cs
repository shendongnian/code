     public ActionResult SaveStaffDetails(RegisterStaffViewModel model,HttpPostedFileBase image)
     {
          if (Request.Files.Count > 0)
                    {
                        string FileName = Guid.NewGuid().ToString().Replace("-", "");
                        string Path = System.IO.Path.GetExtension(Request.Files[0].FileName);
                        string FullPath = "~/Images/StaffPhotos/" + FileName + Path;
                        Request.Files[0].SaveAs(Server.MapPath(FullPath));
                        staffPhoto = FileName + Path;
                    }
    
     }
