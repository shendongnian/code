    private void printDocument1_PrintPage(object sender, 
                                System.Drawing.Printing.PrintPageEventArgs e)
    {
        // my page unit
        e.Graphics.PageUnit = GraphicsUnit.Millimeter;
        // starting a new page
        int itemsOnPage = 0;
        pagesPrinted++;
        float currentY = 12;
        e.Graphics.DrawString(String.Format(
                   "HEADER -  printing {0} items of {1}    - Page {2}",
                   itemsToPrint, totalNumber, pagesPrinted), 
                   Font, Brushes.Black, 1, currentY);  
           
        currentY += 30;  // header height
        try
        {
            // page is not full and we want to print more items
            while (itemsOnPage < itemsPerPage && itemsPrinted < itemsToPrint - 1
                   && DR.Read())
            {
                string row = String.Format("{0,5:000} Artist: {1,20}  ({2})   ",
                                             DR[0], DR[1], DR[2]);
                e.Graphics.DrawString(row, DefaultFont, Brushes.Black, 50, currentY);  
                // Console.WriteLine("" + row);
                currentY += itemHeight; 
                itemsPrinted++; 
                itemsOnPage++;
                // we want to print more items but now the page is full
                if ( itemsPrinted < itemsToPrint && itemsOnPage >= itemsPerPage)
                {
                    itemsOnPage = 0;        
                    e.HasMorePages = true;         
                    return;                 
                }
                else 
                {
                    // this will only be used after all data are printed
                    e.HasMorePages = false; 
                }
            }
        } catch (Exception ef)
        {
            MessageBox.Show("" + ef);
        }
    }
