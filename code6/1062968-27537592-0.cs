    if (printDlg.ShowDialog() == true)
    {
        var printableArea = new Size(printDlg.PrintableAreaWidth, printDlg.PrintableAreaHeight)
        var printControl = new PrintingTemplate();
        //Set the drawing dimensions/boundaries - notice (Acutal)Width/Height = 0
        printControl.Measure(printableArea);
        printControl.Arrange(new Rect(new Point(), printableArea);
        //"Render"!
        printcontrol.UpdateLayout();
        //At this point you should see the (Acutal)Width/Height be > 0!      
        printDlg.PrintVisual(printControl, "User Control Printing.");
    }
