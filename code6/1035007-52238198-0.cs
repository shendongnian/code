    using Excel = Microsoft.Office.Interop.Excel;
    class Program
    {
        static void Main(string[] args)
        {
            Read_From_Excel.ProcessExcel(@"D:\some_place\some_excel.xlsx");
        }
    
    }
    public class Read_From_Excel
    {
        public static void ProcessExcel(string location)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(location);
    
    
            foreach (var xlWorksheet in xlWorkbook.Worksheets)
            {
                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;
    
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
