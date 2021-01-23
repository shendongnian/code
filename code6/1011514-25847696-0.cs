        private void print_btn_Click(object sender, EventArgs e)
        {
             PrinterSettings ps = new PrinterSettings();
             printDialog1.Document = printDocument1;
             printDocument1.PrinterSettings = ps;
            
            this.printDocument1.PrintPage += new PrintPageEventHandler(this.printDocument1_PrintPage);
            printDocument1.Print();            
       }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.CopyFromScreen(new Point(),new Point(),new Size(this.Width,this.Height));
        }
