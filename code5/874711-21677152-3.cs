	public class UploadFileModel 
	{
		public UploadFileModel()
		{
			Files = new List<HttpPostedFileBase>();
		}
		public List<HttpPostedFileBase> Files { get; set; }
        public string FirstName { get; set; }
        // Rest of model details
	}
