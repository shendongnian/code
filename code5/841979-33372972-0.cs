    /// <summary>
    ///   Get current settings (encapsulated in an PrintTicket) for a specific printer.
    /// </summary>
    private static PrintTicket GetPrinterSettings(PrintQueue printer)
    {
       try
       {
          // Note: Because of a bug in the WPF printing classes
          // this hack is unfortunately necessary in order to get the correct 
          // printer settings. The old/usual method often get the printer
          // standard settings instead of the custom settings. 
          // For more information see:
          // https://social.msdn.microsoft.com/Forums/vstudio/en-US/6ebf6d61-a356-41c3-a444-a24fb38416fe/printticket-not-reflecting-printing-preferences?forum=wpf
          // http://stackoverflow.com/questions/20774420/getting-the-changed-printer-preferences-for-a-printer-from-controlpanel-through
             
          var printDialog = new System.Windows.Controls.PrintDialog();
          string printerName = printer.FullName;
          string defaultPrinterName = printDialog.PrintQueue.FullName;
    
          PrintTicket ticket;
          if (defaultPrinterName != printerName)
          {
             // Temporary change default printer in order to get
             // correct printer settings on the specific printer.
             Win32.SetDefaultPrinter(printerName);
             printDialog = new System.Windows.Controls.PrintDialog();
             ticket = printDialog.PrintTicket;
             Win32.SetDefaultPrinter(defaultPrinterName);
          }
          else
             ticket = printDialog.PrintTicket;
          return ticket.Clone();
       }
       catch
       {
          // If the method above fails, use the old method.
          return printer.CurrentJobSettings.CurrentPrintTicket.Clone();
       }
    }
    
    public static class Win32
    {
       [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
       public static extern bool SetDefaultPrinter(string Name);
    }
