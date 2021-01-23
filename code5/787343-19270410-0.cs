    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Excel = Microsoft.Office.Interop.Excel;
    using System.Reflection;
    using System.Data;
    using System.IO;
    using System.Data.OleDb;
    using System.Globalization;
    
    namespace ExcelTemplateFiller
    {
        class Program
        {
            static void Main(string[] args)
            {
                Excel.Application excelApp = null;
                Excel.Worksheet xlSheet;
                Excel.Workbook xlBook;
                try
                {
                    excelApp = new Excel.Application();
                    string templatePath = @"..\..\ExcelTemplate\FTPLogReport.xltx";
                    string CSVPath = @"..\..\Input\08Oct2013_FTPLogReport.csv";
                    string OutputPath = @"..\..\Output\08Oct2013_FTPLogReport.xlsx";
    
                    templatePath = Path.GetFullPath(templatePath);
                    CSVPath = Path.GetFullPath(CSVPath);
                    OutputPath = Path.GetFullPath(OutputPath);
    
                    xlBook = (Excel.Workbook)excelApp.Workbooks.Open(templatePath, Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value);
    
                    int row = 2;
    
                    DataTable dtCSV = CsvFileToDatatable(CSVPath, true);
    
                    foreach (DataRow dr in dtCSV.Rows)
                    {
                        excelApp.Cells[row, 1] = dr[0].ToString();
                        excelApp.Cells[row, 2] = dr[1].ToString();
                        excelApp.Cells[row, 3] = dr[2].ToString();
                        excelApp.Cells[row, 4] = dr[3].ToString();
                        excelApp.Cells[row, 5] = dr[4].ToString();
    
                        row++;
                    }
    
    
    
                    xlSheet = (Excel.Worksheet)xlBook.Worksheets.get_Item(1);
                    xlSheet.Name = "08Oct2013";
    
                    object oFilename = OutputPath;
                    object oFileFormat = Excel.XlFileFormat.xlWorkbookDefault;
                    object oPassword = Missing.Value;
                    object oWriteResPassword = Missing.Value;
                    object oReadOnlyRecommended = false;
                    object oCreateBackup = false;
    
                    Excel.XlSaveAsAccessMode AccessMode = Excel.XlSaveAsAccessMode.xlNoChange;
                    object oConflictResolution = false;
                    object oAddToMru = true;
                    object oTextCodepage = Missing.Value;
                    object oTextVisualLayout = Missing.Value;
                    object oSaveChanges = true;
                    object oRouteWorkbook = Missing.Value;
    
                    excelApp.DisplayAlerts = false;
                    xlBook.SaveAs(oFilename, oFileFormat, oPassword, oWriteResPassword, oReadOnlyRecommended, oCreateBackup, AccessMode, oConflictResolution, oAddToMru, oTextCodepage, oTextVisualLayout);
                    xlBook.Close(oSaveChanges, oFilename, oRouteWorkbook);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    System.Threading.Thread.Sleep(1000);
                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    System.Threading.Thread.Sleep(30000);
                }
    
            }
    
            private static DataTable CsvFileToDatatable(string path, bool IsFirstRowHeader)
            {
                string header = "No";
                string sql = string.Empty;
                DataTable dtCSV = null;
                string pathOnly = string.Empty;
                string fileName = string.Empty;
    
                try
                {
                    pathOnly = Path.GetDirectoryName(path);
                    fileName = Path.GetFileName(path);
    
                    sql = @"SELECT * FROM [" + fileName + "]";
    
                    if (IsFirstRowHeader)
                    {
                        header = "Yes";
                    }
    
                    using (OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathOnly + ";Extended Properties=\"Text;HDR=" + header + "\""))
                    {
                        using (OleDbCommand cmd = new OleDbCommand(sql, connection))
                        {
                            using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                            {
                                dtCSV = new DataTable();
                                dtCSV.Locale = CultureInfo.CurrentCulture;
                                adapter.Fill(dtCSV);
                            }
                        }
    
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return dtCSV;
            }
        }
    }
