    private void MenuItemPrint()
    {
       if (!FileName.Trim().Equals(""))
       {                        
         using(PrintDocument pd = new PrintDocument())
         {
           pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);                        
           pd.Print();
         }
        }
     }
    private void pd_PrintPage(object sender, PrintPageEventArgs ev)
    {
      ev.Graphics.DrawString(FileName, new Font("Arial", 10), Brushes.Black,
                           ev.MarginBounds.Left, 0, new StringFormat());
     }
        
           
                        
          
