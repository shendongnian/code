    using System.Diagnostics;
    ...
    Process[] activeProcess = Process.GetProcessByName(Process.GetCurrentProcess().ProcessName);
    if (activeProcess.Length == 1)
    {
        Application.Run(new YOUR_MAIN_XAML_CLASS_HERE());
    }
    else
    {
        MessageBox.Show("You already have an instance of this program");
    }
