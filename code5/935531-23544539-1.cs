       [HttpPost]
       public void Upload()  //Here just store 'Image' in a folder in Project Directory 
                             //  name 'UplodedFiles'
       {
           foreach (string file in Request.Files)
           {
               var postedFile = Request.Files[file];
               postedFile.SaveAs(Server.MapPath("~/UploadedFiles/") + Path.GetFileName(postedFile.FileName));
           }
       }
         public ActionResult List() //I retrive Images List by using this Controller
	        {
	            var uploadedFiles = new List<Picture>();
	 
	            var files = Directory.GetFiles(Server.MapPath("~/UploadedFiles"));
	 
	            foreach(var file in files)
	            {
	                var fileInfo = new FileInfo(file);
                    var picture = new Picture() { Name = Path.GetFileName(file) };
	                picture.Size = fileInfo.Length;
	 
	                picture.Path = ("~/UploadedFiles/") + Path.GetFileName(file);
	                uploadedFiles.Add(picture);
	            }
	 
	            return View(uploadedFiles);
	        }
