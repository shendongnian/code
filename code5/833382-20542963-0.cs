    using System.Drawing.Printing;
    
    public static PageSettings GetPrinterPageInfo(String printerName) {
      PrinterSettings settings;
    
      if (String.IsNullOrEmpty(printerName)) {
        foreach (var printer in PrinterSettings.InstalledPrinters) {
          settings = new PrinterSettings();
    
          settings.PrinterName = printer.ToString();
    
          if (settings.IsDefaultPrinter)
            return settings.DefaultPageSettings;
        }
        
        return null; // <- No default printer  
      }
    
      settings = new PrinterSettings();
    
      settings.PrinterName = printer.ToString();
    
      return settings.DefaultPageSettings;
    }
    
    public static PageSettings GetPrinterPageInfo() {
      return GetPrinterPageInfo(null);
    }
    
    ...
    
    PageSettings page = GetPrinterPageInfo();
    
    RectangleF area = page.PrintableArea;
    Rectangle bounds = page.Bounds;
    Margins margins = page.Margins;
