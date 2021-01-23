    private void RunElevated(string fileName)
    {
        ProcessStartInfo processInfo = new ProcessStartInfo();
        processInfo.Verb = "runas";
        processInfo.FileName = fileName;
        try
        {
            Process.Start(processInfo);
        }
        catch (Win32Exception)
        {
            //Do nothing. Probably the user canceled the UAC window
        }
    }
