    private void button2_Click(object sender, RoutedEventArgs e)
    {
        UpdateExcel("Sheet3", 4, 7, "Namachi@gmail");
    }
    private void UpdateExcel(string sheetName, int row, int col, string data)
    {
        Microsoft.Office.Interop.Excel.Application oXL = null;
        Microsoft.Office.Interop.Excel._Workbook oWB = null;
        Microsoft.Office.Interop.Excel._Worksheet oSheet = null;
        try
        {
            oXL = new Microsoft.Office.Interop.Excel.Application();
            oWB = oXL.Workbooks.Open("d:\\MyExcel.xlsx");
            oSheet = String.IsNullOrEmpty(sheetName) ? (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet : (Microsoft.Office.Interop.Excel._Worksheet)oWB.Worksheets[sheetName];
            oSheet.Cells[row, col] = data;
            oWB.Save();
            MessageBox.Show("Done!");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        finally
        {
            if (oWB != null)
            oWB.Close();
        }
    }
