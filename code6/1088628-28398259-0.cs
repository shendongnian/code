    public class XlConversion
    {
        public static void MarshalReleaseComObject(object comObject)
        {
            if ((comObject != null) && (Marshal.IsComObject(comObject)))
            {
                Marshal.ReleaseComObject(comObject);
            }
        }
        public static void ConvertTsvToExcel(string inputFullPath, string outputExcelFullPath, bool deleteInput = false)
        {
            if (String.IsNullOrWhiteSpace(inputFullPath))
            {
                throw new ArgumentOutOfRangeException(nameof(inputFullPath));
            }
            if (String.IsNullOrWhiteSpace(outputExcelFullPath))
            {
                throw new ArgumentOutOfRangeException(nameof(outputExcelFullPath));
            }
            var inputFilename = new FileInfo(inputFullPath);
            var xlFilename = new FileInfo(outputExcelFullPath);
            const int maxSupportedXlFilenameLength = 218;
            if (xlFilename.FullName.Length > maxSupportedXlFilenameLength)
            {
                throw new ArgumentOutOfRangeException(nameof(outputExcelFullPath), outputExcelFullPath, ("The full path filename (" + xlFilename.FullName.Length + " characters) is longer than Microsoft Excel supports (" + maxSupportedXlFilenameLength + " characters)"));
            }
            var excelApp = new Application();
            Workbooks wbs = excelApp.Workbooks;
            Workbook wb = wbs.Open(inputFilename.FullName);
            wb.SaveAs(xlFilename.FullName, XlFileFormat.xlOpenXMLWorkbook);
            try
            {
                wb.Close();
                //excel.Quit();
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                MarshalReleaseComObject(wb);
                MarshalReleaseComObject(wbs);
                MarshalReleaseComObject(excelApp);
            }
            if (deleteInput)
            {
                File.Delete(inputFilename.FullName);
            }
        }
    }
