    using (ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process WHERE ProcessId = 1234"))
    {
        foreach (ManagementObject mo in mos.Get())
        {
            Console.WriteLine(mo["CommandLine"]);
        }
    }
