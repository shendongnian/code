    public void Printing() {
       try {
         streamToPrint = new StreamReader (filePath);
         try {
           PrintDocument prd = new PrintDocument(); 
           prd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
           prd.PrinterSettings.PrinterName = printer;
           // Set the page orientation to landscape.
           prd.DefaultPageSettings.Landscape = true;
           prd.Print();
         } 
         finally {
           streamToPrint.Close() ;
         }
       } 
       catch(Exception ex) { 
         MessageBox.Show(ex.Message);
       }
     }
