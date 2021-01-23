    private void button2_Click(object sender, EventArgs e)
    {
        string s = "A50,50,0,2,1,1,N,\"9129302\"\n";
        s += "P1\n";
    
        // Allow the user to select a printer.
        PrintDialog pd = new PrintDialog();
        pd.PrinterSettings = new PrinterSettings();
        if (DialogResult.OK == pd.ShowDialog(this))
        {
            var bytes = Encoding.ASCII.GetBytes(s);
            // Send a printer-specific to the printer.
            RawPrinterHelper.SendBytesToPrinter(pd.PrinterSettings.PrinterName, bytes, bytes.Length);
            MessageBox.Show("Data sent to printer.");
        }
    }
    //elsewhere
    public static class RawPrinterHelper
    {
        //(Snip) The rest of the code you already have
    
        private static bool SendBytesToPrinter(string szPrinterName, byte[] bytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false;
    
            di.pDocName = "Zebra Label";
            di.pDataType = "RAW";
    
    
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    if (StartPagePrinter(hPrinter))
                    {
                        bSuccess = WritePrinter(hPrinter, bytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
                throw new Win32Exception(dwError);
            }
            return bSuccess;
        }
    }
