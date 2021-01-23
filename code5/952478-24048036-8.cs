    [HttpPost]
    public ActionResult Action(ViewModel model)
    {
        if (ModelState.IsValid)
        {
            
            var file = Request.Files["ImageUpload"];
            if (file != null && file.ContentLength > 0){
				var uploadDir = "~/uploads"
				var imagePath = Path.Combine(Server.MapPath(uploadDir), file.FileName);
				var imageUrl = Path.Combine(uploadDir, file.FileName);
				file.SaveAs(imagePath);
				model.ImagePath= imageUrl;
            }
            
        }
    }
