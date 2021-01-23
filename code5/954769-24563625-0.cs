    int currentpage = 0;
    int pagesleft = 0;
    int rec = 0;
    private void Summary_English(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
        rec = rec += 1;
           
        // Title
        // Extra text
        // Table headers
        int rec_count = Details.rec_num.Count; // Counts the total records from file
        int pageCount = (rec_count + 37 - 1) / 37; // Calculates how many pages there should be
        int y = 257;
        currentpage = currentpage + 1;
        if (currentpage == 1)
        {
            pagesleft = pageCount - 1;
        }
        for (; rec < rec_count; rec++)
        {
            e.Graphics.DrawString(Details.rec_num[rec - 1] + "\n", ar_7_reg, Brushes.Black, new System.Drawing.Rectangle(22, y, 32, 485));
            e.Graphics.DrawString(Details.datetime[rec] + "\n", ar_7_reg, Brushes.Black, new System.Drawing.Rectangle(54, y, 96, 485));
            e.Graphics.DrawString(Details.volt[rec] + "V\n", ar_7_reg, Brushes.Black, new System.Drawing.Rectangle(240, y, 40, 485));
            e.Graphics.DrawString(Details.expectedAtime[rec] + " S\n", ar_7_reg, Brushes.Black, new System.Drawing.Rectangle(394, y, 68, 485));
            e.Graphics.DrawString(Details.actualtime1[rec] + " S\n", ar_7_reg, Brushes.Black, new System.Drawing.Rectangle(462, y, 102, 485));
            e.Graphics.DrawString(Details.expectedBtime[rec] + " S\n", ar_7_reg, Brushes.Black, new System.Drawing.Rectangle(564, y, 69, 485));
            e.Graphics.DrawString(Details.actualtime2[rec] + " S\n", ar_7_reg, Brushes.Black, new System.Drawing.Rectangle(633, y, 102, 485));
            e.Graphics.DrawString(Details.error[rec] + "\n", ar_7_reg, Brushes.Black, new System.Drawing.Rectangle(735, y, 92, 485));
            y += 13;
            if (rec % 37 == 0)
            {
                y = 257;
                break;
            }
        }
        e.HasMorePages = currentpage < pageCount;
    }
