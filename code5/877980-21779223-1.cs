    using System;
    using System.Collections.Generic;
    using OfficeOpenXml;
    using System.IO;
    
    
    namespace ConsoleApplication4 {
        class Program {
            static void Main(string[] args) {
                const string buscado = "C:";
                const string reemplazo = "T:";
                const string test = "='" + buscado;
                using (ExcelPackage xls = new ExcelPackage(new FileInfo(@"E:\Libro1.xlsx"))) {
                    ExcelWorksheet sheet = xls.Workbook.Worksheets[1];
                    int row = 1;
                    while (sheet.Cells[row, 1].Value != null) {
                        if (sheet.Cells[row, 1].Text.Substring(0, 4) == test) {
                            sheet.Cells[row, 3].Value = sheet.Cells[row, 1].Value.ToString().Replace(buscado, reemplazo);
                        }
                        row++;
                    }
                    xls.Save();
                }
            }
        }
    }
