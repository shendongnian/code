    Aspose.Words.Document doc = new Aspose.Words.Document();
    // Create first table with 1 row and 2 columns
    Aspose.Words.Tables.Table table = new Aspose.Words.Tables.Table(doc);
    // Add the table to the document.
    doc.FirstSection.Body.AppendChild(table);
    Aspose.Words.Tables.Row row = new Aspose.Words.Tables.Row(doc);
    table.AppendChild(row);
    Aspose.Words.Tables.Cell cell1 = new Aspose.Words.Tables.Cell(doc);
    row.AppendChild(cell1);
    Aspose.Words.Tables.Cell cell2 = new Aspose.Words.Tables.Cell(doc);
    row.AppendChild(cell2);
    table.SetBorders(LineStyle.Dot, 1, System.Drawing.Color.Red);
    // Add the second table in cell1
    Aspose.Words.Tables.Table table2 = new Aspose.Words.Tables.Table(doc);
    cell1.AppendChild(table2);
    Aspose.Words.Tables.Row row2 = new Aspose.Words.Tables.Row(doc);
    table2.AppendChild(row2);
    Aspose.Words.Tables.Cell cell3 = new Aspose.Words.Tables.Cell(doc);
    row2.AppendChild(cell3);
    Aspose.Words.Tables.Cell cell4 = new Aspose.Words.Tables.Cell(doc);
    row2.AppendChild(cell4);
    table2.SetBorders(LineStyle.DotDash, 1, System.Drawing.Color.Blue);
