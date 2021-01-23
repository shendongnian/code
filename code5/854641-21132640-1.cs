    public class SomeController : Controller 
    {
        public ActionResult Create() 
        {
          NewViewModel model = new NewViewModel
          {
             // inicialize list
             UploadItems = new List<UploadItems> 
             {
                // inicialize empty objects ( if you want to have 2 file fields with additional data)
                // or inicialize only one object and another fields add by Javascript
                new UploadItem {},
                new UploadItem {},
             }
          }
          return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewViewModel model) 
        {
            // if (ModelState.IsValid) etc...
            foreach (var uploadItem in model.UploadItems)
            {
                // work with file and additional data
                var file = uploadItem.UpFile;
                var prop1 = uploadItem.CustomProp1;
                // file.SaveAs("/some/where"); atc ...
            }
            // return some view...
        }
    }
