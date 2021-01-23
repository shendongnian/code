    using Excel = Microsoft.Office.Interop.Excel;
    class Program
    {
        static void Main(string[] args)
        {
            ReadExcel.PrintAllCells(@"D:\some_place\some_excel.xlsx");
        }
    
    }
    public class ReadExcel
    {
        public static void PrintAllCells(string location)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(location);
    
    
            foreach (var xlWorksheet in xlWorkbook.Worksheets)
            {
                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;
                // LOOPING THROUGH EXCEL CELLS STARTS WITH 1 
                // NOT WITH 0
    
                for (int column = 1; column < colCount; column++)
                {
                    for (int row = 1; row < rowCount; row++)
                    {
    
                        var CellData = xlRange.Cells[row, column].Value;
                        Console.WriteLine(CellData);
    
                    }
    
                }
    
            }
    
        }
    
    }
