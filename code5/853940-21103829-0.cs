    static void Main(string[] args)
    {
        // Get the process.
        Process target = Process.GetProcesses()
            .First(p => 
                   p.ProcessName.IndexOf("VMWare",
                                         StringComparison.OrdinalIgnoreCase) >= 0);
        // Headshot!
        TerminateProcess(target.Handle, 0);
    }
    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool TerminateProcess(IntPtr hProcess, int uExitCode);
