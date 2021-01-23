    using Microsoft.Office.Interop.Word;
    
    class Program
    {
    	static void Main(string[] args)
        {
    		var application = new Application();
    
    		// Open YOur word file path
          	var document = application.Documents.Open(@"C:\Users\Test\Desktop\Demo.docx");
    
    	    // Get the page count.
    		var numberOfPages = document.ComputeStatistics(WdStatistic.wdStatisticPages, false);
    
            // Print out the result
            Console.WriteLine("Total number of pages in document: {0}", numberOfPages);
    	}
    }
