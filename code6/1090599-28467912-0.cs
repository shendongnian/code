    class MainPageController
    {
      ActionResult Index()
      {
       var model = new MainPageViewModel
       {
        Photos = GetListOfPhotoViewModelsOrderedByAge(SomeDataSource),  
      }
      return View(model)
    }
    
    class MainPageViewModel
    {
     // various other properties
     IList<PhotoViewModels> Photos {get; set;}
    }
    class PhotoViewModel
    {
     // properties to display about the photo (including hte path to the actual image)
    }
