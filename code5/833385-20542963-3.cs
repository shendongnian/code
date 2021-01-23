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
    
      settings.PrinterName = printerName;
    
      return settings.DefaultPageSettings;
    }
    
    // Default printer default page info
    public static PageSettings GetPrinterPageInfo() {
      return GetPrinterPageInfo(null);
    }
    
    ...
    
    // Default printer default page
    PageSettings page = GetPrinterPageInfo(); 
    // Or default page of some other printer given by its name
    // PageSettings page = GetPrinterPageInfo(MyPrinterName); 
    
    RectangleF area = page.PrintableArea;
    Rectangle bounds = page.Bounds;
    Margins margins = page.Margins;
