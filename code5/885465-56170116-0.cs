    public class PrinterSettings
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal class PRINTERDEFAULTSClass
        {
            public IntPtr pDatatype;
            public IntPtr pDevMode;
            public int DesiredAccess;
        } 
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, PRINTERDEFAULTSClass pdc);
        public DEVMODE GetPrinterSettings(string PrinterName)
        {
            DEVMODE dm;
             
            var pdc = new PRINTERDEFAULTSClass
            {
                pDatatype = new IntPtr(0),
                pDevMode = new IntPtr(0),
                DesiredAccess = PRINTER_ALL_ACCESS
            };
            var nRet = Convert.ToInt32(OpenPrinter(PrinterName,
                    out hPrinter, pdc));
        }
    }
