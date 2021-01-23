    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out int lpNumberOfBytesRead);
    ////////////////////////////////////////////////////////////////////
    // These are used to find the StardewValley.Farmer structure     //
    //////////////////////////////////////////////////////////////////
    private IntPtr Thread0Address;
    private IntPtr FarmerStartAddress;
    private static int[] FARMER_OFFSETS = { 0x4, 0x478, 0x218, 0x24C };
    private static int FARMER_FIRST = 0x264;
    //////////////////////////////////////////////////////////////////
    private async void hookAll()
    {
        SVProcess = Process.GetProcessesByName("Stardew Valley")[0];
        SVHandle = OpenProcess(ProcessAccessFlags.All, true, SVProcess.Id);
        SVBaseAddress = SVProcess.MainModule.BaseAddress;
        Thread0Address = (IntPtr) await getThread0Address();
        getFarmerStartAddress();
    }
    private Task<int> getThread0Address()
    {
        var proc = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "threadstack.exe",
                Arguments = SVProcess.Id + "",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            }
        };
        proc.Start();
        while (!proc.StandardOutput.EndOfStream)
        {
            string line = proc.StandardOutput.ReadLine();
            if (line.Contains("THREADSTACK 0 BASE ADDRESS: "))
            {
                bool f = false;
                for (int x = 0; x < line.Length; x++)
                {
                    if (line[x] == ':')
                        if (!f)
                            f = true;
                        else
                            line = line.Substring(x + 2);
                }
                return Task.FromResult(int.Parse(line.Substring(2), System.Globalization.NumberStyles.HexNumber));
            }
        }
        return Task.FromResult(0);
    }
    private void getFarmerStartAddress()
    {
        IntPtr curAdd = (IntPtr) ReadInt32(Thread0Address - FARMER_FIRST);
        foreach (int x in FARMER_OFFSETS)
            curAdd = (IntPtr) ReadInt32(curAdd + x);
        FarmerStartAddress = (IntPtr) curAdd;
    }
    private int ReadInt32(IntPtr addr)
    {
        byte[] results = new byte[4];
        int read = 0;
        ReadProcessMemory(SVHandle, addr, results, results.Length, out read);
        return BitConverter.ToInt32(results, 0);
    }
