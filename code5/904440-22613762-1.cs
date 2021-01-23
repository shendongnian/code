    public static void ExportToCSV(DataTable dt, HttpResponseBase response, string filename)
    {
        response.AddHeader("content-disposition", "attachment; filename=" + filename);
        response.ClearContent();
        response.ContentType = "application/vnd.ms-excel";
        response.Charset = "UTF-8";
        response.ContentEncoding = System.Text.Encoding.Unicode;
        response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble()); 
    
        ExcelPackage package = new ExcelPackage();
        package.Workbook.Properties.Comments = "Demo Excel Generation";
        package.Workbook.Worksheets.Add("DemoSheet");
    
        ExcelWorksheet sheet = package.Workbook.Worksheets["DemoSheet"];
    
        bool altColour = false;
        for (int i = 1; i < 10; i++)
        {
            for (int j = 1; j < 10; j++)
            {
                sheet.Cells[i, j].Value = string.Format("{0} - {1}", i, j);
                sheet.Row(j).Style.Fill.PatternType = ExcelFillStyle.Solid;
                sheet.Row(j).Style.Fill.BackgroundColor.SetColor(altColour ? Color.Gold : Color.Goldenrod);
                altColour = !altColour;
            }
    
            sheet.Column(i).AutoFit(5f); // Set minimum width to 5 points
        }
    
        //package.File = new System.IO.FileInfo(@"C:\test.xlsx");
        //package.Save();
        package.SaveAs(response.OutputStream);
        Response.End();
    }
