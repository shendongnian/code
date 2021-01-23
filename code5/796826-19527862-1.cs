    int nextTop = -1;
    int i = 1;
    private void printDocument1_PrintPage(object sender, PrintPageEventArgs e) {        
        for(;i <= Convert.ToInt32(lblTotalBox.Text); i++){
          lblBoxNumber.Text = i.ToString();
          using (Graphics g = e.Graphics) {
              int y = nextTop == -1 ? e.MarginBounds.Top : nextTop;           
              Bitmap bmp = new Bitmap(350, 400);
              grpReceipt.DrawToBitmap(bmp, new Rectangle(0, 0, 350, 400));
              g.DrawImage(bmp, e.MarginBounds.Left, y);         
              nextTop += bmp.Height + 10;
              if(nextTop > e.MarginBounds.Height - bmp.Height) {
                 nextTop = -1
                 e.HasMorePages = true;
                 return;
              }
          }
        }
    }
    private void btnPrint_Click(object sender, EventArgs e) {
        i = 1;
        PaperSize paperSize = new PaperSize("MyCustomSize", 100, 65);
        paperSize.RawKind = (int)PaperKind.Custom;
        printDocument1.DefaultPageSettings.PaperSize = paperSize;
        printDocument1.Print();
    }
