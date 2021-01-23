                foreach (var a in pavmm.Funds)
                {
                    ws.Cells[i, 1] = a.FilingID;
                    ws.Cells[i, 2] = a.Security_Name; ws.Cells[i, 3] = a.Filing_Type; ws.Cells[i, 4] = a.st_name; ws.Cells[i, 5] = a.Permit;
                   
                    i = i + 1;
                }
                ws.Columns.AutoFit();
                ws.Rows.AutoFit();
            string folder = NewFolderName + "\\";
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
              
                string filename =  ExcelsheetName + ".xlsx";
                filename = filename.Replace('/', '-');
                filename = filename.Replace('\\', '-');
                string path = Path.Combine(folder, filename);
                wb.SaveCopyAs(path);
    
