     //Reference "Windows Image Acquisition Library v2.0" on the COM tab.
    private void Button1_Click(object sender, EventArgs e)
    {
        var dialog = new WIA.CommonDialog();
        var file = dialog.ShowAcquireImage(WIA.WiaDeviceType.ScannerDeviceType);
        file.SaveFile("C:\Temp\WIA." + file.FileExtension);
    }
