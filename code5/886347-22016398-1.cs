    private void MonitoringHandler (object sender, EventArgs e)
    {
        Monitor();
    }
    private void Monitor()
    {
        App.isPrintAllowed = App.monitor.IsPrinterReady();               
    }
