    public static void listTextObjects(string inputPdf)
    {
    	using (PdfDocument pdf = new PdfDocument(inputPdf))
    	{
    		string format = "{0}\n{1}, {2}px at {3}";
    
    		foreach (PdfPage page in pdf.Pages)
    		{
    			foreach (PdfPageObject obj in page.GetObjects())
    			{
    				if (obj.Type != PdfPageObjectType.Text)
    					continue;
    
    				PdfTextData text = (PdfTextData)obj;
    
    				string message = string.Format(format, text.Text, text.Font.Name,
    					text.Size.Height, text.Position);
    				Console.WriteLine(message);
    			}
    		}
    	}
    }
