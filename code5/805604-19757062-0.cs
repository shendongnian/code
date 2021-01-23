        Excel.Application excel = new Excel.Application();
        excel.Visible = true;
        Excel.Workbook wb = excel.Workbooks.Add();
        Excel.Worksheet sh = wb.Sheets.Add();
        sh.Name = "TestSheet";
        
        // Write some kind of loop to write your values in sheet. Here i am adding values in 1st columns
        for (int i = 0; i < list.Count; i++)
        {
           sh.Cells[i.ToString(), "A"].Value2 = list[i];
          
        }
        string filePath = @"C:\output123.xlsx";
         
        // Save file to filePath
        wb.Save(filePath);
        wb.Close(true);
        excel.Quit(); 
