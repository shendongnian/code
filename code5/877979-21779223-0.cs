    using System;
    using System.Collections.Generic;
    using OfficeOpenXml;    //This is the EPPlus reference
    using System.IO;
    
    
        namespace ConsoleApplication4 {
            class Program {
                static void Main(string[] args) {
        
                    using (ExcelPackage xls = new ExcelPackage(new FileInfo(@"E:\Libro1.xlsx"))) {
                        ExcelWorksheet sheet = xls.Workbook.Worksheets[1];
                        int row = 1;
                        while (sheet.Cells[row, 1].Value != null) {
                            sheet.Cells[row, 3].Value = sheet.Cells[row, 1].Value.ToString().Replace("C:", "L:");
                            row++;
                        }
                        xls.Save();
                    }
                }
            }
        }
