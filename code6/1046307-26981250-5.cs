    [HttpGet]
    public ActionResult Create()
    {
      ArticleFormViewModel Model = new ArticleFormViewModel();
      return View(Model);
    }
    [HttpPost]
    public ActionResult Create(ArticleFormViewModel Model)
    {
     if(ModelState.IsValid)
     {
       if(Model.ImageFile != null)
       {
    	 var path = Path.Combine(Server.MapPath("~/articles"), Model.ImageFile.FileName);
    	 try
    	 {
    	   Model.ImageUpload.SaveAs(imagePath);
           
           //Perhaps then save Entity to database using an ORM?
    	 }
    	 catch(Exception e)
    	 {
    	   //Do something..
    	 }
       }
     }
    
     return View(Model);
    }
