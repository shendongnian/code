    public static void OpenPdfDocument(string pdfPath)
    {
        Thread pdfDocuThread = new Thread(
            new ParameterizedThreadStart(OpenPdfHelper));
        pdfDocuThread.SetApartmentState(ApartmentState.STA);
        pdfDocuThread.IsBackground = true;
        pdfDocuThread.Start(pdfPath);
    }
    
    private static void OpenPdfHelper(object pdfPath)
    {
        try
        {
            if (pdfPath is string)
            {
                DisplayPdfWindow pdfViewer = new DisplayPdfWindow();
                pdfViewer.Loaded += (s, ev) => { pdfViewer.SetPdf(pdfPath.ToString()); };
                pdfViewer.Closed += (s, ev) => { pdfViewer.Dispatcher.InvokeShutdown(); };
                pdfViewer.Show();
                Dispatcher.Run();
            }
        }
        catch (Exception ex)
        {
            Mouse.OverrideCursor = null;
            AppErrorLog.LogError("PDFTHREADERROR: " + ex.Message);
        }
    }
