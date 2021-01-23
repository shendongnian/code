    var doc = new Document();
    var sec = doc.AddSection();
    
    // Magic: To read the default values for LeftMargin, RightMargin &c. 
    // assign a clone of DefaultPageSetup.
    // Do not assign DefaultPageSetup directly, never modify DefaultPageSetup.
    sec.PageSetup = doc.DefaultPageSetup.Clone();
    
    var table = sec.AddTable();
    // For simplicity, a single column is used here. Column width == table width.
    var tableWidth = Unit.FromCentimeter(8);
    table.AddColumn(tableWidth);
    var leftIndentToCenterTable = (sec.PageSetup.PageWidth.Centimeter - 
                                   sec.PageSetup.LeftMargin.Centimeter - 
                                   sec.PageSetup.RightMargin.Centimeter -
                                   tableWidth.Centimeter) / 2;
    table.Rows.LeftIndent = Unit.FromCentimeter(leftIndentToCenterTable);
    table.Borders.Width = 0.5;
    var row = table.AddRow();
    row.Cells[0].AddParagraph("Hello, World!");
