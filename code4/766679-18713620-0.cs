    [DllImport("user32.dll")]
    public static extern Boolean GetLastInputInfo(ref tagLASTINPUTINFO plii);
    public struct tagLASTINPUTINFO
    {
        public uint cbSize;
        public Int32 dwTime;
    }
    private void timerTemps_Inactif_Tick(object sender, EventArgs e)
    {
        tagLASTINPUTINFO LastInput = new tagLASTINPUTINFO();
        Int32 IdleTime;
        LastInput.cbSize = (uint)Marshal.SizeOf(LastInput);
        LastInput.dwTime = 0;
        if (GetLastInputInfo(ref LastInput))
        {
            IdleTime = System.Environment.TickCount - LastInput.dwTime;
            if (IdleTime > 10000)
            {
                //My code here
            }
        }
    }
