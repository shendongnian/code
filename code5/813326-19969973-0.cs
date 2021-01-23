    using (WordprocessingDocument myDoc = WordprocessingDocument.Open(docName, true))
    {
    MainDocumentPart mainPart = myDoc.MainDocumentPart;
    Document doc = mainPart.Document;
    //Create new table with predefined table style
    Table table = new Table();
    TableProperties tblPr = new TableProperties();
    TableStyleId tblStyle = new TableStyleId();
    tblStyle.Val = "PredefinedTableStyle";
    tblPr.AppendChild(tblStyle);
    table.AppendChild(tblPr);
    string[] headerContent = new string[] { "Name", "Subcategory", "Price", "Image" };
    //Create header row
    TableRow header = CreateRow(headerContent, null);
    table.AppendChild(header);
    ...
    }
