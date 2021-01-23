    StandardFonts standardfont = StandardFonts.Helvetica;
    PDFFont fontSmall_reg = new PDFFont(standardfont, FontStyle.Regular);
    TableStyle ts = new TableStyle(fontSmall_reg, 12, nullBorder);
    Table data = new Table(ts);
    data.Columns.Add(100);
    data.Columns.Add(100);
    Row r = new Row(data, ts);
    r.Height = 25;
    r.Cells.Add("Row 1 Col1");
    data.add(r)
    r.Cells.Add("Row 1 Col2");
