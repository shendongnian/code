            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            double t2 = 20;
            int t1 = 10;
            int i, j;
            double []s= new double[10];
   
     for (i = 0; i <= t1; i++)
     {
     for (j = 0; j <= t2; j++)
     {
       
          xlWorkSheet.Cells[(i+1), (j+1)] = s[(j / 2)];
        
         Excel.Range chartRange;
         Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
         Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(100, 80, 300, 250);
         Excel.Chart chartPage = myChart.Chart;
         chartRange = xlWorkSheet.get_Range("A1", "Z10");
         j += 1;
         chartPage.SetSourceData(chartRange, misValue);
      
         chartPage.ChartType = Excel.XlChartType.xlXYScatterSmooth;
      }
    }
        xlWorkBook.SaveAs("link1.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue)
