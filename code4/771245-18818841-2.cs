    int pages = 0;
    private void Doc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
    //...
        for (int z = pages * 15; z < dt.Rows.Count; z++)
        {
           for (int d = 0; d < dt.Columns.Count; d++)
             {
                 //draw text
             }
           if (z - pages * 15 == 15)
           { e.HasMorePages = true; Rows = 0; pages++; break; }
           else { e.HasMorePages = false; }
           Rows++;
        }
    } 
