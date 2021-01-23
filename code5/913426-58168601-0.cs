    private string ConvertToExcel(string CSVpath, string EXCELPath)
        {
            try
            {
                string Filename = System.IO.Path.GetFileNameWithoutExtension(CSVpath);
                string DirectoryName = System.IO.Path.GetDirectoryName(CSVpath);
                EXCELPath = DirectoryName + "\\" + Filename + ".xlsx";
                string worksheetsName = "Report";
                bool firstRowIsHeader = false;
                var format = new OfficeOpenXml.ExcelTextFormat();
                format.Delimiter = '|';
                format.EOL = "\n";
                using (OfficeOpenXml.ExcelPackage package = new OfficeOpenXml.ExcelPackage(new System.IO.FileInfo(EXCELPath)))
                {
                    string dateformat = "m/d/yy h:mm";
                    //string dateformat = System.Globalization.DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                    OfficeOpenXml.ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(worksheetsName);
                    worksheet.Cells["A1"].LoadFromText(new System.IO.FileInfo(CSVpath), format, OfficeOpenXml.Table.TableStyles.Medium2, firstRowIsHeader);
                  
                    worksheet.Column(3).Style.Numberformat.Format = dateformat;
                    worksheet.Column(5).Style.Numberformat.Format = dateformat;
                    worksheet.Column(6).Style.Numberformat.Format = dateformat;
                    worksheet.Column(20).Style.Numberformat.Format = dateformat;
                    worksheet.Column(21).Style.Numberformat.Format = dateformat;
                    worksheet.Column(22).Style.Numberformat.Format = dateformat;
                    package.Save();
                }
            }
            catch (Exception ex)
            {
                //DAL.Operations.Logger.LogError(ex);
                Console.WriteLine(ex);
                Console.Read();
            }
            return EXCELPath;
        }
