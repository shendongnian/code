    private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
            pageCount++;
            if(pageCount >= fromPage)
            {
                // print your grid
            }
            if (bMorePagesToPrint && pageCount <= toPage)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;    
    }
