    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;
    
    //pathToExcel is filename of the existing file
    using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(pathToExcel, true))
        {
           //Get workbookpart
           WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
           WorkbookStylesPart wbsp = CreateStylesheet(workbookPart.WorkbookStylesPart);
           //then access to the worksheet part
           List<WorksheetPart> worksheetPart = workbookPart.WorksheetParts.ToList();                 
           foreach (WorksheetPart WSP in worksheetPart)
           {                    
               //find sheet data
               IEnumerable<SheetData> sheetData = WSP.Worksheet.Elements<SheetData>();
               //Iterate through every sheet inside Excel sheet                    
               foreach (SheetData SD in sheetData)
               {                         
                   IEnumerable<Row> row = SD.Elements<Row>(); // Get the row                                                                    
                   int rowindex = 1;
                   foreach (Row currentrow in row)
                   {
                       foreach (Cell cell in currentrow.Descendants<Cell>())
                       {
                           //Doing Wordwrap in the cell using openxml - in open xml we need to do cell level word wrap
                           cell.StyleIndex = Convert.ToUInt32(1);
                       }
                       //Here Row AutoFit property is not available, setting the row height manually and skipping 1st two rows
                       if (rowindex > 2)
                       {
                           currentrow.Height = currentrow.Height + 5;
                           currentrow.CustomHeight = true;                               
                       }                         
                       rowindex++; 
                  }
            }
         WSP.Worksheet.Save();         
     }
     //workbookPart.Workbook.Save();
     spreadsheetDocument.Close();
    }
    private static WorkbookStylesPart CreateStylesheet(WorkbookStylesPart spreadsheet)
    {
       WorkbookStylesPart stylesheet = spreadsheet;
       Stylesheet workbookstylesheet = new Stylesheet(); 
       // <CellFormats>
       CellFormat cellformat0 = new CellFormat() { FontId = 0, FillId = 0, BorderId = 0 }; // Default style : Mandatory
       CellFormat cellformat1 = new CellFormat(new Alignment() { WrapText = true });  
       //Style with textwrap set
       Fills fills = new Fills();
       Fill fill;
       PatternFill patternFill;
       fill = new Fill();
       patternFill = new PatternFill();
       patternFill.PatternType = PatternValues.None;
       fill.PatternFill = patternFill;
       fills.Append(fill);
    
      //<APENDING CellFormats>
      CellFormats cellformats = new CellFormats();
      cellformats.Append(cellformat0);
      cellformats.Append(cellformat1);
    
      // Append FONTS, FILLS , BORDERS & CellFormats to stylesheet <Preserve the ORDER>            
       workbookstylesheet.Append(fills);
       workbookstylesheet.Append(cellformats);
    
       // Finalize
       stylesheet.Stylesheet = workbookstylesheet;
       stylesheet.Stylesheet.Save();
    
       return stylesheet;
    }
