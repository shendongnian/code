    using (var ms = new MemoryStream())
    		{
    			using (var doc = new Document(PageSize.LETTER, 220f, 30f, 115f, 100f)){
    		
    				try
    				{
    				  pdfPage page = new pdfPage();
    				  PdfWriter writer = PdfWriter.GetInstance(doc, ms);
    				  writer.PageEvent = page;
    				  doc.Open();
    
    				iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(RESOURCE);
    				img.ScalePercent(49f);
    				//img.Width = doc.PageSize.Width;
    				//img.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
    				img.SetAbsolutePosition(-8, 
    					doc.PageSize.Height - 180.6f);
    				doc.Add(img);
