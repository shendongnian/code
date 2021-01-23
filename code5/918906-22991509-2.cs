    [HttpPost]
            public ActionResult Upload(FormCollection form,HttpPostedFileBase file)
            {
                //HttpPostedFileBase file = Request.Files[0 ];
    
                Uploads uploadsModel = new Uploads();
     
                uploadsModel.bookingdid = long.Parse(form["bookingdid"]);
                uploadsModel.FileName = file.FileName;
                uploadsModel.FilePath = "~/Uploads/" + file.FileName;
    
                if (file.ContentLength < 1048576)
                {
    
                    if (file != null)
                    {
                        file.SaveAs(Server.MapPath(uploadsModel.FilePath));
                    }
    
                    TestDetailsViewModel objTestDetails = new TestDetailsViewModel();
                    objTestDetails.SaveFile(uploadsModel);
                }
                
                return PartialView("~/Views/Shared/_UploadsPartial.cshtml",uploadsModel);
            }
