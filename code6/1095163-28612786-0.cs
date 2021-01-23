    using (Stream output = new MemoryStream())
    {
    	using (PdfDocument pdf = new PdfDocument(@"input.pdf"))
    	{
    		PdfDrawOptions options = PdfDrawOptions.CreateFitSize(new PdfSize(200, 200), false);
    		options.BackgroundColor = new PdfGrayColor(100);
    		pdf.Pages[0].Save(output, options);
    	}
    }
