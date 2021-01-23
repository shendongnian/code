    Bitmap img;
    private void btnPrintForm_Click(object sender, EventArgs e)
    {
        CaptureScreen();
        printDocument1.Print();
        printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
    }
    private void CaptureScreen()
    {
        Graphics g = this.CreateGraphics();
        Size s = this.Size;
        img = new Bitmap(s.Width, s.Height, g);
        Graphics mg = Graphics.FromImage(img);
        mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
    }
    private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
		e.Graphics.DrawImage(img, 0, 0);
    }
