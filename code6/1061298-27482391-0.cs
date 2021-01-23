    private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1170); // all sizes are converted from mm to inches & then multiplied by 100.
                pd.PrintPage += printDocument_PrintPage; //event handler fire
                //pd.PrinterSettings = PrinterSettings.InstalledPrinters.
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while printing", ex.ToString());
            }
        }
    
      
     private void printDocument_PrintPage(object sender, PrintPageEventArgs ev)
        {
            Graphics graphic = ev.Graphics;
            foreach (DataRow row in dataGridView1.Rows)
                {
                    string text = row.ToString() //or whatever you want from the current row
                    graphic.DrawString(text,new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, 20, 225);
                }
        }
