    protected void Button1_OnClick(object sender, EventArgs e)
    {
        //Create the table from the textbox
        var dt = new DataTable();
        dt.Columns.Add("Column1");
        var dr = dt.NewRow();
        dr[0] = TextArea1.InnerText;
        dt.Rows.Add(dr);
        var excelDocName = @"c:\temp\temp.xlsx";
        var aFile = new FileInfo(excelDocName);
        if (aFile.Exists)
            aFile.Delete();
        var pck = new ExcelPackage(aFile);
        var ws = pck.Workbook.Worksheets.Add("Content");
        ws.Cells["A1"].LoadFromDataTable(dt, true);
        ws.Cells["A1:A2"].Style.WrapText = true;  //false by default
        pck.Save();
    }
