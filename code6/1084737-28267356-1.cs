    public static void printText(string inputPdf)
    {
    	using (PdfDocument pdf = new PdfDocument(inputPdf))
    	{
    		foreach (PdfPage page in pdf.Pages)
    		{
    			string text = page.GetTextWithFormatting();
    			Console.WriteLine(text);
    		}
    	}
    }
