    static void Main(string[] args)
    {
        Thread.Sleep(2000);
        // push V key
        keybd_event((byte)ScanCodeShort.KEY_V, 0x45, 0, 0);
        Console.WriteLine("done");
        Console.Read();
    }
