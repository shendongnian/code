     //Check to see if path exists
            if (!File.Exists(path1))
            {
                //if file does not exist, 
                MessageBox.Show("File does not exixt.");
            }
            //if exists, it will open the file to write to it
            else
            {
                workBook1 = exlApp.Workbooks.Open(path1, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true,
                    false, 0, true, false, false);
            }
            workBook2 = exlApp.Workbooks.Open(path2, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true,
                   false, 0, true, false, false);
           
            
           
            //Get the cell to copy the contents from 
            Excel.Range sourceRange = workBook1.Sheets[1].Range("A1");
            //Get the destination cell(in a different workbook) to copy
            Excel.Range destinationRange = workBook2.Sheets[1].Range("B2");
            sourceRange.Copy(destinationRange);
            
