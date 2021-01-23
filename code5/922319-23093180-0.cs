        static void OpenCSVWithExcel(string path)
        {
            var ExcelApp = new Excel.Application();
            ExcelApp.Workbooks.OpenText( path, Comma:true);
            ExcelApp.Visible = true;
        }
