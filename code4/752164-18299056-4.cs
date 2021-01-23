    private void printToolStripButton_Click(object sender, EventArgs e)
        {
            PrintDocument document = new PrintDocument();
            document.PrintPage += new PrintPageEventHandler(document_PrintPage);
            PrintPreviewDialog preview = new PrintPreviewDialog() { Document = document };
            // you will be able to preview all pages before print it ;)
            try
            {
                preview.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nYou need to install a printer to preform print-related tasks!", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        Boolean firstPage = true;
        private void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (firstPage)
            {
                tabControlMain.SelectTab(0);
                firstPage = false;
            }
            Graphics g = e.Graphics;
            TabPage tab = tabControlMain.SelectedTab;
            using (Bitmap img = new Bitmap(tab.Width, tab.Height))
            {
                tab.DrawToBitmap(img, tab.ClientRectangle);
                g.DrawImage(img, new Point(e.MarginBounds.X, e.MarginBounds.Y)); // MarginBounds means the margins of the page 
            }
            if (tabControlMain.SelectedIndex + 1 < tabControlMain.TabCount)
            {
                tabControlMain.SelectedIndex++;
                e.HasMorePages = true;//If you set e.HasMorePages to true, the Document object will call this event handler again to print the next page.
            }
            else
            { 
                e.HasMorePages = false;
                firstPage = true;
            } 
        }
