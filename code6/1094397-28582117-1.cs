    protected void ConvertHTMLToPDF(String HTMLCode, String fileName)
    {    
    	//Create PDF document 
    	iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4);
    	PdfWriter.GetInstance(doc, new FileStream(HttpContext.Current.Server.MapPath("~") + "/Resources/Temp/" + fileName, FileMode.Create));
    	doc.Open();
    
    	foreach (IElement element in HTMLWorker.ParseToList(new StringReader(HTMLCode), null))                
    	{
    		doc.Add(element);
    	}
    
    	doc.Close();
    	//Response.End();
    
    }
