	Color SuperColor = Color.FromArgb(192, 0, 0);
	styleH.FillForegroundColor = GetXLColour(hssfworkbook, SuperColor);
	private short GetXLColour(HSSFWorkbook workbook, System.Drawing.Color SystemColour)
	{
	    short s = 0;
	    HSSFPalette XlPalette = workbook.GetCustomPalette();
	    NPOI.HSSF.Util.HSSFColor XlColour = XlPalette.FindColor(SystemColour.R, SystemColour.G, SystemColour.B);
	    if (XlColour == null)
	    {
	        if (NPOI.HSSF.Record.PaletteRecord.STANDARD_PALETTE_SIZE < 255)
	        {
	            if (NPOI.HSSF.Record.PaletteRecord.STANDARD_PALETTE_SIZE < 64)
	            {
	                NPOI.HSSF.Record.PaletteRecord.STANDARD_PALETTE_SIZE = 64;
	                NPOI.HSSF.Record.PaletteRecord.STANDARD_PALETTE_SIZE += 1;
	                XlColour = XlPalette.AddColor(SystemColour.R, SystemColour.G, SystemColour.B);
	            }
	            else
	            {
	                XlColour = XlPalette.FindSimilarColor(SystemColour.R, SystemColour.G, SystemColour.B);
	            }
	            s = XlColour.GetIndex();
	        }
	    }
	    else
	        s = XlColour.GetIndex();
	    return s;
	}  
