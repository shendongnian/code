                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                Excel._Application xlApp = new Excel.Application();
    
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            //add data 
            xlWorkSheet.Cells[1, 1] = 13;
            xlWorkSheet.Cells[1, 2] = 27;
            xlWorkSheet.Cells[1, 3] = 22;
            xlWorkSheet.Cells[1, 4] = 22;
            xlWorkSheet.Cells[2, 1] = 42    ;
            xlWorkSheet.Cells[2, 2] = 35;
            xlWorkSheet.Cells[2, 3] = 22;
            xlWorkSheet.Cells[2, 4] = 22;
            xlWorkSheet.Cells[3, 1] = 1;
            xlWorkSheet.Cells[3, 2] = 10;
            xlWorkSheet.Cells[3, 3] = 4;
            xlWorkSheet.Cells[3, 4] = 4;
            Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(10, 80, 300, 250);
            Excel.Chart chartPage = myChart.Chart;
            myChart.Select();
            chartPage.ChartType = Excel.XlChartType.xlXYScatterLines;
            Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();
            Excel.SeriesCollection seriesCollection = chartPage.SeriesCollection();
            Excel.Series series1 = seriesCollection.NewSeries();
            series1.XValues = xlWorkSheet.get_Range("A1", "B1"); ;
            series1.Values = xlWorkSheet.get_Range("C1", "D1");
            Excel.Series series2 = seriesCollection.NewSeries();
            series2.XValues = xlWorkSheet.get_Range("A2", "B2"); ;
            series2.Values = xlWorkSheet.get_Range("C2", "D2");
            Excel.Series series3 = seriesCollection.NewSeries();
            series3.XValues = xlWorkSheet.get_Range("A3", "B3"); ;
            series3.Values = xlWorkSheet.get_Range("C3", "D3"); 
            
            xlWorkBook.SaveAs(@"C:\ProgramData\RadiolocationQ\Text.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
         
            Process.Start(@"C:\ProgramData\RadiolocationQ\Text.xls");
