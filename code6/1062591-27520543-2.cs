    using Microsoft.Office.Interop.Excel;
    public void DataSetsToExcel(List<DataSet> dataSets, string fileName)
    {
    Microsoft.Office.Interop.Excel.Application xlApp = 
              new Microsoft.Office.Interop.Excel.Application();
    Workbook xlWorkbook = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
    Sheets xlSheets = null;
    Worksheet xlWorksheet = null;
    foreach (DataSet dataSet in dataSets)
    {
        System.Data.DataTable dataTable = dataSet.Tables[0];
        int rowNo = dataTable.Rows.Count;
        int columnNo = dataTable.Columns.Count;
        int colIndex = 0;
        //Create Excel Sheets
        xlSheets = xlWorkbook.Sheets;
        xlWorksheet = (Worksheet)xlSheets.Add(xlSheets[1], 
                       Type.Missing, Type.Missing, Type.Missing);
        xlWorksheet.Name = dataSet.DataSetName;
        //Generate Field Names
        foreach (DataColumn dataColumn in dataTable.Columns)
        {
            colIndex++;
            xlApp.Cells[1, colIndex] = dataColumn.ColumnName;
        }
        object[,] objData = new object[rowNo, columnNo];
        //Convert DataSet to Cell Data
        for (int row = 0; row < rowNo; row++)
        {
            for (int col = 0; col < columnNo; col++)
            {
                objData[row, col] = dataTable.Rows[row][col];
            }
        }
        //Add the Data
        Range range = xlWorksheet.Range[xlApp.Cells[2, 1], xlApp.Cells[rowNo + 1, columnNo]];
        range.Value2 = objData;
        //Format Data Type of Columns 
        colIndex = 0;
        foreach (DataColumn dataColumn in dataTable.Columns)
        {
            colIndex++;
            string format = "@";
            switch (dataColumn.DataType.Name)
            {
                case "Boolean":
                    break;
                case "Byte":
                    break;
                case "Char":
                    break;
                case "DateTime":
                    format = "dd/mm/yyyy";
                    break;
                case "Decimal":
                    format = "$* #,##0.00;[Red]-$* #,##0.00";
                    break;
                case "Double":
                    break;
                case "Int16":
                    format = "0";
                    break;
                case "Int32":
                    format = "0";
                    break;
                case "Int64":
                    format = "0";
                    break;
                case "SByte":
                    break;
                case "Single":
                    break;
                case "TimeSpan":
                    break;
                case "UInt16":
                    break;
                case "UInt32":
                    break;
                case "UInt64":
                    break;
                default: //String
                    break;
            }
            //Format the Column accodring to Data Type
            xlWorksheet.Range[xlApp.Cells[2, colIndex], 
                  xlApp.Cells[rowNo + 1, colIndex]].NumberFormat = format;
        }
    }
    //Remove the Default Worksheet
    ((Worksheet)xlApp.ActiveWorkbook.Sheets[xlApp.ActiveWorkbook.Sheets.Count]).Delete();
    //Save
    xlWorkbook.SaveAs(fileName,
        System.Reflection.Missing.Value,
        System.Reflection.Missing.Value,
        System.Reflection.Missing.Value,
        System.Reflection.Missing.Value,
        System.Reflection.Missing.Value,
        XlSaveAsAccessMode.xlNoChange,
        System.Reflection.Missing.Value,
        System.Reflection.Missing.Value,
        System.Reflection.Missing.Value,
        System.Reflection.Missing.Value,
        System.Reflection.Missing.Value);
    xlWorkbook.Close();
    xlApp.Quit();
    GC.Collect();
    }
