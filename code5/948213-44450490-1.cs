        	using (var reader = new PdfReader(inputPdf))
    			{
    
    				var parser = new PdfReaderContentParser(reader);
    
    				var strategy = parser.ProcessContent(pageNumber, new LocationTextExtractionStrategyWithPosition());
    
    				var res = strategy.GetLocations();
    
    				reader.Close();
                 }
    				var searchResult = res.Where(p => p.Text.Contains(searchText)).OrderBy(p => p.Y).Reverse().ToList();
			
	
    inputPdf is a byte[] that has the pdf data
    
    pageNumber is the page where you want to search in
