    static void Main(string[] args)
    {
        Thread.Sleep(2000);
        // push V key
        keybd_event((byte)ScanCodeShort.KEY_V, 0x45, 0, 0);
        // release V key (if don't, the key still pushed)
        keybd_event((byte)ScanCodeShort.KEY_V, 0x45, KEYEVENTF_KEYUP, 0);
        Console.WriteLine("done");
        Console.Read();
    }
