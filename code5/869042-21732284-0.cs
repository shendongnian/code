    class PrintDocument1 : PrintDocument
    {
    	int currentPage;
    	bool isPreview;
    
    	protected override void OnBeginPrint(PrintEventArgs e)
    	{
    		currentPage = 0;
    		isPreview = e.PrintAction == PrintAction.PrintToPreview;
    	}
    
    	protected override void OnPrintPage(PrintPageEventArgs e)
    	{
    		currentPage++;
    
    		if (isPreview)
    		{
    			// simplified page drawing
    			
    			e.Graphics.FillRectangle(Brushes.BurlyWood, e.MarginBounds);
    			e.Graphics.DrawString("Page #" + currentPage, SystemFonts.CaptionFont, Brushes.Black, e.MarginBounds.Location);
    		}
    		else
    		{
    			// full page drawing
    
    			Bitmap[] bmaps = new Bitmap[] {
    				SystemIcons.Application.ToBitmap(),
    				SystemIcons.Information.ToBitmap(),
    				SystemIcons.Question.ToBitmap(),
    				SystemIcons.Warning.ToBitmap(),
    				SystemIcons.Shield.ToBitmap(),
    				SystemIcons.Error.ToBitmap()
    			};
    
    			Point p = e.MarginBounds.Location;
    			for (int i = 0; p.Y < e.MarginBounds.Bottom; i++, p.Y += 40)
    			{
    				e.Graphics.DrawString("Some text goes here, line " + (i + 1), SystemFonts.CaptionFont, Brushes.Black, p);
    				e.Graphics.DrawLine(Pens.CadetBlue, e.MarginBounds.Left, p.Y, e.MarginBounds.Right, p.Y);
    				for (int j = 0; j < bmaps.Length; j++)
    					e.Graphics.DrawImage(bmaps[j], p.X + 200 + j * 40, p.Y);
    			}
    		}
    
    		e.HasMorePages = currentPage < 700; // a lot of pages to draw
    	}
    }
    // above class can be previewed and printed next way:
    // PrintPreviewDialog d = new PrintPreviewDialog();
    // d.Document = new PrintDocument1();
    // d.ShowDialog();
