    PrintDialog pd = new PrintDialog();
    if (pd.ShowDialog() == true)
    {
       Rect printableArea = GetPrintableArea(printDlg);
       
       // I'm using here a viewbox for easily adjust the canvas_Letter to the desired size
       Viewbox viewBox = new Viewbox { Child = canvas_Letter };
       viewBox.Measure(printableArea.Size);
       viewBox.Arrange(printableArea);
       printDlg.PrintVisual(viewBox, "Letter Canvas");
    }
    private static Rect GetPrintableArea(PrintDialog printDialog)
    {
       PrintCapabilities cap;
       try
       {
          cap = printDialog.PrintQueue.GetPrintCapabilities(printDialog.PrintTicket);
       }
       catch (PrintQueueException)
       {
          return Rect.Empty;
       }
       if (cap.PageImageableArea == null)
       {
          return Rect.Empty;
       }
       var leftMargin = cap.OrientedPageMediaWidth.HasValue ? (cap.OrientedPageMediaWidth.Value - cap.PageImageableArea.ExtentWidth) / 2 : 0;
       var topMargin = cap.OrientedPageMediaHeight.HasValue ? (cap.OrientedPageMediaHeight.Value - cap.PageImageableArea.ExtentHeight) / 2 : 0;
       var width = cap.PageImageableArea.ExtentWidth;
       var height = cap.PageImageableArea.ExtentHeight;
       return new Rect(leftMargin, topMargin, width, height);
    }
