    protected void Button1_Click(object sender, EventArgs e)
         {
            //String strDefaultPrinter;
            //SetDefaultPrinter("doPDF v7");
            PrintDialog printDialog = new PrintDialog();
            PrintDocument documentToPrint = new PrintDocument();
            printDialog.Document = documentToPrint;
            documentToPrint.PrinterSettings.PrinterName = "canon LBP2900 on CHSADMIN-PC";
            StringReader reader = new StringReader(TextBox1.Text);
            documentToPrint.PrintPage += new PrintPageEventHandler(DocumentToPrint_PrintPage);
            documentToPrint.Print();
        }
        private void DocumentToPrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringReader reader = new StringReader(TextBox1.Text);
            float LinesPerPage = 0;
            float YPosition = 0;
            int Count = 0;
            float LeftMargin = e.MarginBounds.Left;
            float TopMargin = e.MarginBounds.Top;
            string Line = null;
            Font PrintFont = SystemFonts.DefaultFont;
            System.Drawing.SolidBrush PrintBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            PrintServer ps = new PrintServer();
            //pd.PrinterSettings.PrinterName = printer;
            LinesPerPage = e.MarginBounds.Height / PrintFont.GetHeight(e.Graphics);
            //DefaultHttpHandler ip = new DefaultHttpHandler();
            
            while (Count < LinesPerPage && ((Line = reader.ReadLine()) != null))
            {
                YPosition = TopMargin + (Count * PrintFont.GetHeight(e.Graphics));
                e.Graphics.DrawString(Line, PrintFont, PrintBrush, LeftMargin, YPosition, new StringFormat());
                Count++;
            }
            if (Line != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
            PrintBrush.Dispose();
        }
