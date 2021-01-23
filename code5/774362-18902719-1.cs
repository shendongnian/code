    public static void insertBlanksAndMerge()
    {
    	string[] filesToMerge = { "file1.pdf", "file2.pdf" };
    	
    	// open first file
    	int pagesBefore = 0;
    	using (PdfDocument pdf = new PdfDocument(filesToMerge[0]))
    	{
    		pdf.InsertPage(pagesBefore + 3);
    
    		// append all other documents
    		for (int i = 1; i < filesToMerge.Length; i++)
    		{
                pagesBefore = pdf.PageCount;
    			pdf.Append(filesToMerge[i]);
    			pdf.InsertPage(pagesBefore + 3);
    		}
    
    		pdf.Save(@"out.pdf");
    	}
    }
