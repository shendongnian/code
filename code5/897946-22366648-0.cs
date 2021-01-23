    using Microsoft.Office.Interop.Excel;
    using System.IO;
    using System;
    public class ExcelInterop : IDisposable
    {
        private Application _excelApplication;
        
        public ExcelInterop()
        {
            _excelApplication = new Application();
        }
        
        public void ConvertDirectoryOfCsvFilesToTxt(string inputFolder, string outputFolder)
        {
            var files = Directory.GetFiles(seasonPath).Where(f => !f.EndsWith(".csv")).ToList();
            
            foreach(string file in files)
            {
                string outFilePath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(file) + ".txt";
                ConvertCsvToTxt(file, outFilePath));
            }
        }
        
        private void ConvertCsvToTxt(string inputFilePath, string outputFilePath)
        {
            Workbook workbook = _excelApp.Workbooks.Open(inputFilePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            workbook.SaveAs(outputFilePath, XlFileFormat.xlCurrentPlatformText, Type.Missing, Type.Missing, false);
            workbook.Close();
            Marshal.ReleaseComObject(workbook);
        }
        
        public void Dispose()
        {
            _excelApplication.Quit();
            Marshal.ReleaseComObject(_excelApplication);
        }
    }
