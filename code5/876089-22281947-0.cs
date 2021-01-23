    Microsoft.Office.Interop.Visio.Application application = 
    		new Microsoft.Office.Interop.Visio.Application();  
    application.Visible = false; 
    Microsoft.Office.Interop.Visio.Document doc = application.Documents.Add(templatePath);
    Microsoft.Office.Interop.Visio.Page page = application.Documents[1].Pages[1];
  
