    public static void SendBytesToLocalPrinter(byte[] data, string printerName)
    {
       var size = Marshal.SizeOf(data[0]) * data.Length;
       var pBytes = Marshal.AllocHGlobal(size);
       try
       {
          SendBytesToPrinter(printerName, pBytes, size);
       }
       finally
       {
          Marshal.FreeCoTaskMem(pBytes);
       }
    }
