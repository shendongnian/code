    using System.Drawing.Printing;
        
    public static PageSettings GetPrinterPageInfo(String printerName) {
      PrinterSettings settings;
    
      // If printer name is not set, look for default printer
      if (String.IsNullOrEmpty(printerName)) {
        foreach (var printer in PrinterSettings.InstalledPrinters) {
          settings = new PrinterSettings();
    
          settings.PrinterName = printer.ToString();
    
          if (settings.IsDefaultPrinter)
            return settings.DefaultPageSettings;
        }
        
        return null; // <- No default printer  
      }
    
      // printer by its name 
      settings = new PrinterSettings();
    
      settings.PrinterName = printer.ToString();
    
      return settings.DefaultPageSettings;
    }
    
    // Default printer default page info
    public static PageSettings GetPrinterPageInfo() {
      return GetPrinterPageInfo(null);
    }
    
    ...
    
    PageSettings page = GetPrinterPageInfo();
    
    RectangleF area = page.PrintableArea;
    Rectangle bounds = page.Bounds;
    Margins margins = page.Margins;
