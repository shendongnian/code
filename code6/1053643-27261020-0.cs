    using System.Runtime.InteropServices;
    using Microsoft.Office.Interop.Excel;
    namespace exceltest
    {
    class Program
    {
        
        static void Main(string[] args)
        {
            Microsoft.Office.Interop.Excel.Application xl = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = xl.Workbooks.Open(@"C:\test.xlsx");
            Microsoft.Office.Interop.Excel.Worksheet sheet = workbook.Sheets[1];
            xl.Visible = true;
            //use this if you want to use native Excel functions (such as index)
            Microsoft.Office.Interop.Excel.WorksheetFunction wsFunc = xl.WorksheetFunction;
            int maxNum = 100; // set maximum number of rows/columns to search
            string from = "blah";
            string to = "blum";
            //this is pretty slow, since it has to interact with 10,000 cells in Excel
            // just one example of how to access and set cell values           
            for (int col = 1; col <= maxNum; col++)
            {
                for (int row = 1; row <= maxNum; row ++)
                {
                    Range cell = (Range)sheet.Cells[row, col];
                    if ((string)cell.Value == from) //cast to string to avoid null reference exceptions
                    {
                        cell.Value = to;
                    }
                }
            }
        }
    }
}
