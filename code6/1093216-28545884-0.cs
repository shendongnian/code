    private void _print()
     {
          PrintDialog printDlg = new System.Windows.Controls.PrintDialog();
           PrintTicket pt = printDlg.PrintTicket;
           Double printableWidth = pt.PageMediaSize.Width.Value;
           Double printableHeight = pt.PageMediaSize.Height.Value;
           Double xScale = (printableWidth - xMargin * 2) / printableWidth;
           Double yScale = (printableHeight - yMargin * 2) / printableHeight;
            this.Transform = new MatrixTransform(xScale, 0, 0, yScale, xMargin, yMargin);
        //now print the visual to printer to fit on the one page.
         printDlg.PrintVisual(this, "Print Page");
    }
