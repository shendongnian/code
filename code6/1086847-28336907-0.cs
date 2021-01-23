             Public void Excel()
            {
             Microsoft.Office.Interop.Excel.Application app;
             Workbook workbook = null;
             Worksheet worksheet = null;
             Range range = null;   
             int i,j,k=1;
             app = new Microsoft.Office.Interop.Excel.Application();
             app.Visible = false;
             workbook = app.Workbooks.Add(1);
             worksheet = (Worksheet)workbook.Sheets[1];
             worksheet.Name = "Sheet1";  
             worksheet.Cells.Locked = false;
            //Column1
            j = 1;
            range = worksheet.Rows.get_Range("A" + j.ToString(), "A" + j.ToString());
            range.Font.Size = 11;
            ((Range)worksheet.Cells[j, 1]).EntireColumn.ColumnWidth = 15;
            range.Font.Bold = true;
            range.MergeCells = true;
            range.HorizontalAlignment = Constants.xlCenter;
            //Content
            worksheet.Cells[j, 1] = "Name";
            //Column2
            range = worksheet.Rows.get_Range("B" + j.ToString(), "B" + j.ToString());
            range.Font.Size = 11;
            ((Range)worksheet.Cells[j, 2]).EntireColumn.ColumnWidth = 15;
            range.Font.Bold = true;
            range.MergeCells = true;
            range.HorizontalAlignment = Constants.xlCenter;
            //Content
            worksheet.Cells[j, 2] = "Address";
            //Column3
            range = worksheet.Rows.get_Range("C" + j.ToString(), "C" + j.ToString());
            range.Font.Size = 11;
            ((Range)worksheet.Cells[j, 3]).EntireColumn.ColumnWidth = 15;
            range.Font.Bold = true;
            range.MergeCells = true;
            range.HorizontalAlignment = Constants.xlCenter;
            //Content
            worksheet.Cells[j, 3] = "Contact Number";
           //Loop
            DataTable dt = new DataTable();
   
            for (i = 0; i < dt.Rows.Count; i++)
           {
                //Column1
                range = worksheet.Rows.get_Range("A" + k.ToString(), "A" + k.ToString());
                worksheet.Cells[k, 1] = dt.Rows[i]["NAME"].ToString();
                //Column2
                range = worksheet.Rows.get_Range("B" + k.ToString(), "B" + k.ToString());
                worksheet.Cells[k, 2] = dt.Rows[i]["ADDRESS"].ToString();
                //Column3
                range = worksheet.Rows.get_Range("C" + k.ToString(), "C" + k.ToString());
                worksheet.Cells[k, 3] = dt.Rows[i]["CONTACT_NUMBER"].ToString();
                
                k = k +1;
           }
}
