    var dlg = new PrintDialog();
    var result = dlg.ShowDialog();
    if (result == null || !(bool)result)
        return;
    var page = new Viewbox { Child = new InspectionFormPrintView { DataContext = this.DataContext } };
    page.Measure(new Size(dlg.PrintableAreaWidth, dlg.PrintableAreaHeight));
    page.Arrange(new Rect(new Point(0, 0), page.DesiredSize));
    Dispatcher.BeginInvoke(new Action(() => dlg.PrintVisual(page, "UnitHistory Inspection Form")), DispatcherPriority.ApplicationIdle, null);
