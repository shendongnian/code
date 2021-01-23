     private Font printFont;//class variable
     private void MenuItemPrint()
        {
                if (!FileName.Trim().Equals(""))
                {
                   Printing()
                }
        }
    // The PrintPage event is raised for each page to be printed. 
            private void pd_PrintPage(object sender, PrintPageEventArgs ev)
            {
               
                float yPos = 0;
                float leftMargin = ev.MarginBounds.Left;
               
                    ev.Graphics.DrawString(FileName, printFont, Brushes.Black,
                       leftMargin, yPos, new StringFormat());
            }
    
            public void Printing()
            {
               
                try
                {
                        printFont = new Font("Arial", 10);
                        PrintDocument pd = new PrintDocument();
                        pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                        // Pri nt the document.
                        pd.Print();
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
