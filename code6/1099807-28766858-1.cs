    private void ExportToExcel(DataGridView dv)
    {
        Excel.Application xlApp;
    
        xlApp = new Excel.Application();
        xlApp.Visible = true;
        xlApp.AskToUpdateLinks = false;
        xlApp.DisplayAlerts = false;
    
        Excel.Workbook wb = (Excel.Workbook)xlApp.Workbooks.Add();
        Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets.Add();
    
        int rowstartindex = 1;
        
        //Create headers
        for (int i = 0; i < dv.Columns.Count; i++)
        {
            Excel.Range CellHeadersRange = ws.get_Range(GetExcelColumnName(i+1) + rowstartindex.ToString(), GetExcelColumnName(i+1) + rowstartindex.ToString());
            CellHeadersRange.Value = dv.Columns[i].HeaderText;
    
        }
    
        //Write data
        for (int i = 0; i < dv.Rows.Count; i++)
        {
            for (int j = 0; j < dv.Columns.Count; j++)
            {
                Excel.Range CellDataRange = ws.get_Range(GetExcelColumnName(j+1) + (i+rowstartindex+1).ToString());
                CellDataRange.Value = dv[j, i].Value;
                
                //Verify that backgroundcolor of datagrid is not RGB(0,0,0,0) and in that case apply datagridviewcell color to excel range
                if(!dv.Rows[i].Cells[j].Style.BackColor.IsEmpty)
                    CellDataRange.Interior.Color = dv.Rows[i].Cells[j].Style.BackColor;
    
                //Verify that font style exist before checking for bold and in that case apply datagridviewcell font.bold property to excel range
                if(dv.Rows[i].Cells[j].Style.Font != null)
                    CellDataRange.Font.Bold = dv.Rows[i].Cells[j].Style.Font.Bold;
            }
        }
    
        wb = null;
        ws = null;
        xlApp = null;
    
        GC.Collect();
        GC.WaitForPendingFinalizers();
    
    }
