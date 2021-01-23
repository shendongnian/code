    		public class ModelToCreate
    		{
    			//Some properties
    			public FileUploadModel Files { get; set; }
    		}
    
    		public class FileUploadModel
    		{
    			public FileUploadModel()
    			{
    				Files = new List<HttpPostedFileBase>();
    			}
    
    			public List<HttpPostedFileBase> Files { get; set; }
    		}
    
    Controller actions:
    
    		public ActionResult Create()
    		{
    			var model = new FileUploadModel();
    
    			return View(model);
    
    		}
    
    		[HttpPost]
    		public ActionResult Create(FileUploadModel model)
    		{
    			var file = model.Files[0];
    			return View(model);
    		}
