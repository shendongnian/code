    private void MonitoringHandler (object sender, EventArgs e)
    {
        Monitor();
    }
    private void Monitor()
    {
        if (App.monitor.IsPrinterReady() == false)
        {
            App.isPrintAllowed = false;               
        }
        else
        {
            App.isPrintAllowed = true;
        }
    }
