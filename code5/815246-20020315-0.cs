    private void MenuItemPrint()
     {
       if(!string.IsNullOrEmpty(FileName.Trim())
       {
        PrintDialog printdg = new PrintDialog();
            
        if (printdg.ShowDialog() == DialogResult.OK)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrinterSettings = printdg.PrinterSettings;
            pd.PrintPage += PrintPage;
            pd.Print();
            pd.Dispose();
         }
      }
    }
    private void PrintPage(object o, PrintPageEventArgs e)
    {
       e.Graphics.DrawString(FileName, new Font("Arial", 20), Brushes.Black, 10, 25);
    }
