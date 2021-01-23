     private Font printFont;//class variable
     private void MenuItemPrint()
        {
                if (!FileName.Trim().Equals(""))
                {
                        printFont = new Font("Arial", 10);
                        PrintDocument pd = new PrintDocument();
                        pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                        // Print the document.
                        pd.Print();
                }
        }
            // The PrintPage event is raised for each page to be printed. 
            private void pd_PrintPage(object sender, PrintPageEventArgs ev)
            {
                    ev.Graphics.DrawString(FileName, printFont, Brushes.Black,
                       ev.MarginBounds.Left, 0, new StringFormat());
            }
    
           
                        
          
