        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        private Application _excelApp;
        private Workbook _excelWorkBook;
        private Worksheet _excelSheet;
        private void CloseExcelApp()
        {
            int hWnd = _excelApp.Application.Hwnd;
            uint processID;
            GetWindowThreadProcessId((IntPtr)hWnd, out processID);
            Process.GetProcessById((int)processID).Kill();
            _excelWorkBook = null;
            _excelApp = null;
            _excelSheet = null;
        }
