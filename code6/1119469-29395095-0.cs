    var miViewToPrint = new ucFormToPrintView();
    miViewToPrint.DataContext = ((ucFormToPrintView)CCForm).DataContext;
    // layout, i.e. measure and arrange
    miViewToPrint.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
    miViewToPrint.Arrange(new Rect(miViewToPrint.DesiredSize));
    ...
    if (saveFileDialog.ShowDialog() == true)
    {
        using (var stream = saveFileDialog.OpenFile())
        {
            encoder.Save(stream);
        }
        System.Diagnostics.Process.Start(saveFileDialog.FileName);
    }
