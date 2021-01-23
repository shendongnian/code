     private void printBothGraphs_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog custom = new PrintPreviewDialog();
            custom.ClientSize = new Size(1000, 750);
          
            System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
          
            pd.DefaultPageSettings.Color = true;
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPageBoth);
           
            custom.Document = pd;
            
            
            custom.ShowDialog();
        }
        private void pd_PrintPageBoth(object sender, PrintPageEventArgs ev)
        {
            // Create and initialize print font 
            System.Drawing.Font printFont = new System.Drawing.Font("Arial", 10);
            ev.PageSettings.Color = true;
            // Create Rectangle structure, used to set the position of the chart Rectangle 
            Rectangle myRec = new System.Drawing.Rectangle(ev.MarginBounds.X, ev.MarginBounds.Y, ev.MarginBounds.Width, ev.MarginBounds.Height / 2);
            Rectangle myRec2 = new System.Drawing.Rectangle(ev.MarginBounds.X, ev.MarginBounds.Height / 2 + 90, ev.MarginBounds.Width, ev.MarginBounds.Height / 2);
            //dataChart and outputGraph are two mscharts in my form
            dataChart.Printing.PrintPaint(ev.Graphics, myRec);
            outputGraph.Printing.PrintPaint(ev.Graphics, myRec2);
        }
