    /// <summary>Show or hide the simulation status window on its own thread.</summary>
    private void toggleSimulationStatusWindow(bool show)
    {
        if (show)
        {
            if (statusMonitorThread != null) return;
            statusMonitorWindow = new AnalysisStatusWindow(ExcelApi.analyisStatusMonitor);
            statusMonitorThread = new System.Threading.Thread(delegate()
            {
                Application.Run(statusMonitorWindow);
            });
            statusMonitorThread.Start();
        }
        else if (statusMonitorThread != null)
        {
            statusMonitorWindow.BeginInvoke((MethodInvoker)delegate { statusMonitorWindow.Close(); });
            statusMonitorThread.Join();
            statusMonitorThread = null;
            statusMonitorWindow = null;
        }
    }
