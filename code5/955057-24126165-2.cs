        static void Main(string[] args) {
            using (FileStream stream = new FileStream(@"C:\Users\bblack\Test\TestWorksheet.xlsx", FileMode.Append))  {
                using (ExcelPackage xl = new ExcelPackage(stream)) {
                    // xl by default contains one workbook;
                    bool test;
                    foreach (ExcelWorksheet sheet in xl.Workbook.Worksheets) {
                        test = NamedRangeExists("NamedRange", sheet);
                    }
                }
            }
        }
        static bool NamedRangeExists(string name, ExcelWorksheet ws) {
            return ws.Names.Where(n => n.Name == name).Count() > 0;
        }
