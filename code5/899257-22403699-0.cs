    public class ExcelComponent
    {
        private static Excel.Application _app;
        public static App
        {
            get
            {
                if (_app == null)
                    _app = new Excel.Application();
                return _app;
            }
        }
    }
    private void Create_Excel_File_Click(object sender, EventArgs e)
    {
        Excel.Application xlApp = ExcelComponent.App;
        Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(misValue);
        // etc.
    }
