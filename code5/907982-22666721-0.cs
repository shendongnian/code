    using System;
    using System.Data;
    using System.Windows;
    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace DatagridDemo
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                //Define Datatble
                DataTable dt = new DataTable();
    
                //Create Excel Application Instance
                Excel.Application ExcelApp = new Excel.Application();
    
                //Create workbook Instance and open the workbook from the below location
                Excel.Workbook ExcelWorkBook = ExcelApp.Workbooks.Open(@"E:\test.xlsx");
    
                dt.Columns.Add("EmpNo", typeof(int));
                dt.Columns.Add("EmpName", typeof(string));
    
    
                for (int i = 1; i < dt.Columns.Count + 1; i++)
                {
                    ExcelApp.Cells[1, i] = dt.Columns[i - 1].ColumnName;
                }
    
                //Create DataRow
                DataRow dr = dt.NewRow();
    
                dr[0] = 1;
                dr[1] = "ABC";
    
                ExcelApp.Cells[2, 1] = dr[0].ToString();
                ExcelApp.Cells[2, 2] = dr[1].ToString();
    
                dt.Rows.Add(dr);
    
                dr = dt.NewRow();
    
                dr[0] = 2;
                dr[1] = "DEF";
    
                ExcelApp.Cells[3, 1] = dr[0].ToString();
                ExcelApp.Cells[3, 2] = dr[1].ToString();
    
                dt.Rows.Add(dr);
    
                dr = dt.NewRow();
    
                dr[0] = 3;
                dr[1] = "XYZ";
    
                ExcelApp.Cells[4, 1] = dr[0].ToString();
                ExcelApp.Cells[4, 2] = dr[1].ToString();
    
                dt.Rows.Add(dr);
    
                //Save the workbook
                ExcelWorkBook.Save();
    
                //Close the workbook
                ExcelWorkBook.Close();
    
                //Quit the excel process
                ExcelApp.Quit();
            }
        }
    }
