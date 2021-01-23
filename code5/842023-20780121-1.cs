    counter = 1;
    lastindex = 0;
    private void PrinBt_Click(object sender, EventArgs e)
    {
        if (PagePrintSetup.ShowDialog() == DialogResult.OK)
        {
           counter = 1;
           lastindex = 0;
    
            PrintDocument Pages = new PrintDocument();
            Pages.DefaultPageSettings.PrinterSettings = PagePrintSetup.PrinterSettings;
            Pages.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(Pages_PrintPage);
            Pages.Print();
        }
    }
