    private void button2_Click(object sender, EventArgs e)
    {
        string s = "A50,50,0,2,1,1,N,\"9129302\"\n";
        s += "P1\n";
    
        // Allow the user to select a printer.
        PrintDialog pd = new PrintDialog();
        pd.PrinterSettings = new PrinterSettings();
        if (DialogResult.OK == pd.ShowDialog(this))
        {
            // Send a printer-specific to the printer.
            RawPrinterHelper.SendBytesToPrinter(pd.PrinterSettings.PrinterName, Encoding.ASCII.GetBytes(s));
            MessageBox.Show("Data sent to printer.");
        }
    }
