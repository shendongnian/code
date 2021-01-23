	class ImportantMessageService
	{
		public string Message { get; set; }
	}
	
	// in locator
	SimpleIoc.Default.Register<ImportantMessageService>();
	
	// in page 1
	var service = SimpleIoc.Default.GetInstance<ImportantMessageService>();
	service.Message = "Hello world";
	
	// in page 2
	var service = SimpleIoc.Default.GetInstance<ImportantMessageService>();
	MessageBox.Show(service.Message);
