            //Initialize a new PDF Document
    		Document _document = new Document();   
            
            _document.Title = "Аpitron Sample";
    		_document.Author = "StanlyF";
    		_document.Creator = "АPItron LTD.";
    		
    		Page page = null;
    		PDFGraphics graphics = null;
            
    		Table _table =  new Table();
    	    _table.Columns.Add(30);
            Row row = new Row(_table);
            row.Height = 25;
            row.Cells.Add("ABC");
            _table.Rows.Add(row);
    		while (_table != null)
    		{
    			//Initialize new page with default PageSize A4
    			page = new Page(PageSize.A4);
                
                //Add page to document
    			_document.Pages.Add(page);
                //Get the PDFGraphics object for drawing to the page.
    			graphics = page.Graphics;
    			_table = graphics.DrawTable(100,200, _table); 
    			
    		}
           			
    		using(FileStream _fs = new FileStream("Table_Sample.pdf", System.IO.FileMode.Create, System.IO.FileAccess.Write))  
    		{
    			//Generate PDF to the stream
    			_document.Generate(_fs);
    		    Process.Start("Table_Sample.pdf");
    		}
