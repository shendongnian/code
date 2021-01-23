    public class Test
    {
        private Font printFont;
        private List<string> _documentLinesToPrint = new List<string>();
        public void Run()
        {
            try
            {
                _documentLinesToPrint.Add("Test1");
                _documentLinesToPrint.Add("Test2");
                printFont = new Font("Arial", 10);
                var pd = new PrintDocument();
                pd.DefaultPageSettings.Margins = new Margins(25, 25, 25, 25);
                pd.DefaultPageSettings.PaperSize = new PaperSize("Label", 400, 237);
                var printerSettings = new System.Drawing.Printing.PrinterSettings();
                printerSettings.PrinterName = "Brother QL-570 LE";
                pd.PrinterSettings = printerSettings;
                pd.PrinterSettings.Copies = 1;
                pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                pd.Print();
            }
            catch (InvalidPrinterException exc)
            {
                // handle your errors here.
            }
            catch (Exception ex)
            {
                // handle your errors here.
            }
        }
        // The PrintPage event is raised for each page to be printed. 
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            try
            {
                float linesPerPage = 0;
                float yPos = 0;
                int count = 0;
                float leftMargin = ev.MarginBounds.Left;
                float topMargin = ev.MarginBounds.Top;
                string line = null;
                // Calculate the number of lines per page.
                linesPerPage = ev.MarginBounds.Height /
                   printFont.GetHeight(ev.Graphics);
                // Print each line of the file. 
                while ((count < linesPerPage) && (count < _documentLinesToPrint.Count))
                {
                    line = _documentLinesToPrint[count];
                    yPos = topMargin + (count *
                       printFont.GetHeight(ev.Graphics));
                    ev.Graphics.DrawString(line, printFont, Brushes.Black,
                       leftMargin, yPos, new StringFormat());
                    line = null;
                    count++;
                }
                // If more lines exist, print another page. 
                if (line != null)
                    ev.HasMorePages = true;
                else
                    ev.HasMorePages = false;
            }
            catch (InvalidPrinterException exc)
            {
                // handle your errors here.
            }
            catch (Exception ex)
            {
                // handle your errors here.
            }
        }
    }
