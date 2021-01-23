    void _printWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        var worker = (BackgroundWorker)sender;
        worker.ReportProgress(0);
        _receiptReport = new Receipt(_invoice.InvoiceID, _invoice.ItemsinInvoice.Count);
        worker.ReportProgress(1);
        printerSettings = new System.Drawing.Printing.PrinterSettings();
        ...
        ...
        worker.ReportProgress(6);
        instanceReportSource.ReportDocument = _receiptReport;
        worker.ReportProgress(7);
        reportProcessor.PrintReport(instanceReportSource, printerSettings);
        worker.ReportProgress(8);
    }
    private void _printWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        ProgressBar1.Value = e.ProgressPercentage;
    }
