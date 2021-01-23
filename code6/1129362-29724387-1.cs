    public void getAvailableRAM()
    {
        ComputerInfo CI = new ComputerInfo();
        ulong mem = ulong.Parse(CI.AvailablePhysicalMemory.ToString());
        lbl_Avilable_Memory.Text = (mem / (1024 * 1024) + " MB").ToString();
    }
